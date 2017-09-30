using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Loja.Dominio;
using Loja.Repositorios.SqlServer.EF;
using System.Collections.Generic;

namespace Loja.WebApi.Controllers
{
    public class ProdutosController : ApiController
    {
        private readonly LojaDbContext _db = new LojaDbContext();

        public ProdutosController()
        {
            //TODO: Serialização vc Proxy
            _db.Configuration.ProxyCreationEnabled = false;
        }
		
        // GET: api/Produtos
        public List<Produto> GetProdutos()
        {
            return _db.Produtos.Include(p => p.Categoria).ToList(); 
        }

        // GET: api/Produtos/5
        [ResponseType(typeof(Produto))]
        public IHttpActionResult GetProduto(int id)
        {
            Produto produto = _db.Produtos.Include(p => p.Categoria).SingleOrDefault(p => p.Id == id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        // PUT: api/Produtos/5
        [ResponseType(typeof(void))]
        //PUT é igual UPDATE
        public IHttpActionResult PutProduto([FromUri]int id, [FromBody]Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produto.Id)
            {
                return BadRequest();
            }

            _db.Entry(produto).State = EntityState.Modified;
            produto.Categoria = _db.Categorias.Find(produto.Categoria.ID);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Produtos
        [ResponseType(typeof(Produto))]
        public IHttpActionResult PostProduto(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            produto.Categoria = _db.Categorias.Find(produto.Categoria.ID);
            _db.Produtos.Add(produto);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = produto.Id }, produto);
        }

        // DELETE: api/Produtos/5
        [ResponseType(typeof(Produto))]
        public IHttpActionResult DeleteProduto(int id)
        {
            Produto produto = _db.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            _db.Produtos.Remove(produto);
            _db.SaveChanges();

            return Ok(produto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProdutoExists(int id)
        {
            return _db.Produtos.Count(e => e.Id == id) > 0;
        }
    }
}
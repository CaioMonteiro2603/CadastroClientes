using CadastroClientes.Models;
using CadastroClientes.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.Controllers
{
    public class Categoria2Controller : Controller
    {
        private readonly ICategoriaReposoritory _categoriaRepository;
        

        public Categoria2Controller(ICategoriaReposoritory categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
            

        }
        public IActionResult Index()
        {
            
            var categoria = _categoriaRepository.FindAll();

            return View(categoria);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(CategoriaModelcs categoriaModelcs)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoriaRepository.Insert(categoriaModelcs);
                    TempData["MensagemSucesso"] = "Categoria criada com sucesso!";
                    return RedirectToAction(nameof(Index));
                }

                return View(categoriaModelcs);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ação não concluída, descrição do erro: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Editar(int id)
        {
            var categoria = _categoriaRepository.FindById(id);

            if(categoria == null)
            {
                return NotFound(); 
            }

            return View();
        }

        [HttpPost]
        public IActionResult Editar(CategoriaModelcs categoriaModelcs)
        {
            _categoriaRepository.Update(categoriaModelcs);
            return RedirectToAction(nameof(Index)); 
        }

        public IActionResult DeletarConfirma(int id) 
        {
            CategoriaModelcs categoriaModelcs = _categoriaRepository.FindById(id);
            return View(categoriaModelcs); 
        }

        public IActionResult Deletar(int id)
        {
            try
            {
                bool apagarCategoria = _categoriaRepository.Delete(id);
                if (apagarCategoria)
                {
                    TempData["MensagemSucesso"] = "Apagado!";
                }
                else
                {
                    TempData["MensagemErro"] = "Sua busca não retornou nada!";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao deletar cleinte, tipo de erro: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

    }
}

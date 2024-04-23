using CadastroClientes.Models;
using CadastroClientes.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace CadastroClientes.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Criar(ClienteModel clienteModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _clienteRepository.Insert(clienteModel);
                    TempData["MensagemSucesso"] = "Cliente criado com sucesso!"; 
                    RedirectToAction(nameof(Index));
                }

                return View(clienteModel);
            } catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ação não concluída, descrição do erro: {ex.Message}"; 
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var cliente = _clienteRepository.FindById(id);

            if(cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        public IActionResult Editar(ClienteModel clienteModel)
        {
            _clienteRepository.Update(clienteModel);
            return RedirectToAction(nameof(Index)); 
        }

        public IActionResult DeletarConfirma(int id)
        {
            ClienteModel clienteModel = _clienteRepository.FindById(id);

            return View(clienteModel);
        }
        public IActionResult Deletar(int id)
        {
            try
            {
                bool apagarCliente = _clienteRepository.Delete(id);
                if(apagarCliente)
                {
                    TempData["MensagemSucesso"] = "Apagado!";
                } else
                {
                    TempData["MensagemErro"] = "Sua busca não retornou nada!"; 
                }
                return RedirectToAction(nameof(Index)); 
            } catch(Exception ex) 
            {
                TempData["MensagemErro"] = $"Erro ao deletar cleinte, tipo de erro: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }


    }
}

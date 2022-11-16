using ControleDeDocumentos.Models;
using ControleDeDocumentos.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeDocumentos.Controllers
{
    public class DocumentoController : Controller
    {
        private readonly IDocumentoRepository _documentoRepository;
        public DocumentoController(IDocumentoRepository documentoRepository)
        {
            _documentoRepository = documentoRepository;
        }
        public IActionResult Index()
        {
            List<DocumentoModel> documentos = _documentoRepository.BuscarTodos();
            return View(documentos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            DocumentoModel documento = _documentoRepository.ListarDocumentoPorId(id);
            return View(documento);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            DocumentoModel documento = _documentoRepository.ListarDocumentoPorId(id);
            return View(documento);
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _documentoRepository.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Documento apagado com sucesso.";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu documento";
                }
                       
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu documento, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult CadastrarDocumentoNoBanco(DocumentoModel documento)
        {
            try
            {
                var listaTiposPermitidos = new List<string>()
                {
                    "pdf",
                    "doc",
                    "xls",
                    "docx",
                    "xlsx"
                };

                if (!listaTiposPermitidos.Contains(documento.Arquivo.Split('.').Last()))
                {
                    TempData["MensagemErro"] = $"Ops, não é permitido anexar arquivos deste tipo.";
                    return RedirectToAction("Index");
                }

                if (ModelState.IsValid)
                {
                    _documentoRepository.Adicionar(documento);
                    TempData["MensagemSucesso"] = "Documento cadastrado com sucesso.";
                    return RedirectToAction("Index");
                }

                return View("Criar", documento);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu documento, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult AlterarDocumentosNoBanco(DocumentoModel documento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _documentoRepository.Atualizar(documento);
                    TempData["MensagemSucesso"] = "Documento alterado com sucesso.";
                    return RedirectToAction("Index");
                }
                return View("Editar", documento);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu documento, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}

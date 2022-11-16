using ControleDeDocumentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeDocumentos.Repositories
{
    public interface IDocumentoRepository
    {
        DocumentoModel ListarDocumentoPorId(int id);
        List<DocumentoModel> BuscarTodos();
        DocumentoModel Adicionar(DocumentoModel documento);
        DocumentoModel Atualizar(DocumentoModel documento);
        bool Apagar(int id);
    }
}

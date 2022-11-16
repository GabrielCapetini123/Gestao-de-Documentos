using ControleDeDocumentos.Data;
using ControleDeDocumentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeDocumentos.Repositories
{
    public class DocumentoRepository : IDocumentoRepository
    {
        private readonly BancoContext _bancoContext;
        public DocumentoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public DocumentoModel ListarDocumentoPorId(int id)
        {
            return _bancoContext.Documentos.FirstOrDefault(x => x.Id == id);
        }
        public List<DocumentoModel> BuscarTodos()
        {
            return _bancoContext.Documentos.ToList();
        }
        public DocumentoModel Adicionar(DocumentoModel documento)
        {
            //gravar no banco de dados
                _bancoContext.Documentos.Add(documento);
                _bancoContext.SaveChanges();
                return documento;
        }

        public DocumentoModel Atualizar(DocumentoModel documento)
        {
            DocumentoModel documentoDB = ListarDocumentoPorId(documento.Id);
            if (documentoDB == null) throw new System.Exception("Houve um erro na atualização do documento");

            documentoDB.Codigo = documento.Codigo;
            documentoDB.Titulo = documento.Titulo;
            documentoDB.Processo = documento.Processo;
            documentoDB.Categoria = documento.Categoria;
            documentoDB.Arquivo = documento.Arquivo;

            _bancoContext.Documentos.Update(documentoDB);
            _bancoContext.SaveChanges();
            return documentoDB;
        }

        public bool Apagar(int id)
        {
            DocumentoModel documentoDB = ListarDocumentoPorId(id);

            if (documentoDB == null) throw new System.Exception("Houve um erro na exclusão do documento");

            _bancoContext.Documentos.Remove(documentoDB);
            _bancoContext.SaveChanges();

            return true;

        }
    }
}

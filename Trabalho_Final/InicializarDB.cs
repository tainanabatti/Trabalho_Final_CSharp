using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE;

namespace Trabalho_Final
{
    public class InicializarDB
    {
        DBProjetoFinalEntities db = new DBProjetoFinalEntities();

        public void initialize()
        {
            InicializarDB dbinit = new InicializarDB();
            dbinit.inicializaMarca();
            dbinit.inicializaModelo();
            dbinit.inicializaFipe();
        }
        private void inicializaMarca()
        {
            if (db.Marcas.ToList().Count == 0)
            {
                db.Marcas.Add(new Marcas()
                {
                    Id = 1,
                    Nome = "Volkswagen"
                });
                db.Marcas.Add(new Marcas()
                {
                    Id = 2,
                    Nome = "Honda"
                });
                db.Marcas.Add(new Marcas()
                {
                    Id = 3,
                    Nome = "Mistubishi"
                });
                db.SaveChanges();
            }
        }

        private void inicializaModelo()
        {
            if (db.Modelos.ToList().Count == 0)
            {
                db.Modelos.Add(new Modelos()
                {
                    Id = 1,
                    MarcaId = 1,
                    Nome = "Golf GTI"
                });
                db.Modelos.Add(new Modelos()
                {
                    Id = 2,
                    MarcaId = 1,
                    Nome = "Jetta TSI"
                });
                db.Modelos.Add(new Modelos()
                {
                    Id = 3,
                    MarcaId = 2,
                    Nome = "Civic"
                });
                db.Modelos.Add(new Modelos()
                {
                    Id = 4,
                    MarcaId = 3,
                    Nome = "Lancer Evolution"
                });
                db.SaveChanges();
            }
        }

        private void inicializaFipe()
        {
            if (db.FIPE.ToList().Count == 0)
            {
                db.FIPE.Add(new FIPE()
                {
                    Id = 1,
                    ModeloId = 1,
                    Ano = 2018,
                    Valor = 133254.00
                });
                db.FIPE.Add(new FIPE()
                {
                    Id = 2,
                    ModeloId = 2,
                    Ano = 2018,
                    Valor = 95850.00
                });
                db.FIPE.Add(new FIPE()
                {
                    Id = 3,
                    ModeloId = 3,
                    Ano = 2018,
                    Valor = 91058.00
                });
                db.FIPE.Add(new FIPE()
                {
                    Id = 4,
                    ModeloId = 4,
                    Ano = 2015,
                    Valor = 140275.00
                });
                db.SaveChanges();
            }
        }
    }
}

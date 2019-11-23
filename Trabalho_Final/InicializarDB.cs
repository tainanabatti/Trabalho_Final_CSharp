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
                    Nome = "Ford"
                });
                db.Marcas.Add(new Marcas()
                {
                    Id = 2,
                    Nome = "Hyundai"
                });
                db.Marcas.Add(new Marcas()
                {
                    Id = 3,
                    Nome = "Chevrolet"
                });
                db.SaveChanges();
            }
        }

        private void inicializaModelo()
        {
            int id_marca = getIdMarca();
            if (db.Modelos.ToList().Count == 0)
            {
                db.Modelos.Add(new Modelos()
                {
                    Id = 1,
                    MarcaId = id_marca -1,
                    Nome = "Elantra"
                });
                db.Modelos.Add(new Modelos()
                {
                    Id = 2,
                    MarcaId = id_marca -2,
                    Nome = "Captiva"
                });
                db.Modelos.Add(new Modelos()
                {
                    Id = 3,
                    MarcaId = id_marca,
                    Nome = "Fiesta"
                });
                db.Modelos.Add(new Modelos()
                {
                    Id = 4,
                    MarcaId = id_marca,
                    Nome = "Focus"
                });

                db.SaveChanges();
            }
        }

        private void inicializaFipe()
        {
            int modelo_id = getIdModelo();
        
                if (db.FIPE.ToList().Count == 0)
                {
                    db.FIPE.Add(new FIPE()
                    {
                        Id = 1,
                        ModeloId = modelo_id,
                        Ano = 2019,
                        Valor = 100000.00
                    });
                    db.FIPE.Add(new FIPE()
                    {
                        Id = 2,
                        ModeloId = modelo_id-1,
                        Ano = 2016,
                        Valor = 97500.00
                    });
                    db.FIPE.Add(new FIPE()
                    {
                        Id = 3,
                        ModeloId = modelo_id-2,
                        Ano = 2017,
                        Valor = 80000.00
                    });
                    db.FIPE.Add(new FIPE()
                    {
                        Id = 4,
                        ModeloId = modelo_id-3,
                        Ano = 2015,
                        Valor = 120000.00
                    });
                    db.SaveChanges();
                }
          
        }

        private int getIdMarca()
        {
            List<Marcas> marcas = this.db.Marcas.ToList();
            int id_marca = 0;
            if (marcas != null && marcas.Count > 0)
            {
                id_marca = marcas.Last().Id;
            }
            id_marca = id_marca;
            return id_marca;
        }

        private int getIdModelo()
        {
            List<Modelos> modelos = this.db.Modelos.ToList();
            int id_modelo = 0;
            if (modelos != null && modelos.Count > 0)
            {
                id_modelo = modelos.Last().Id;
            }
            id_modelo = id_modelo;
            return id_modelo;
        }
    }
}

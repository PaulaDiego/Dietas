using Dietas.Models;
using Dietas.Repository;
using System;
using System.Linq;

namespace Dietas.Service
{
    public class DietasService : IDietasService
    {
        private IDietasRepository DietasRepository;
        public DietasService(IDietasRepository _DietasRepository)
        {
            this.DietasRepository = _DietasRepository;
        }
        public Dieta Create(Dieta Dieta)
        {
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Dieta.FechaCreacion = DateTime.Now;
                        Dieta = DietasRepository.Create(Dieta);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
                return Dieta;
            }
        }

        public IQueryable<Dieta> ReadDietas()
        {
            using (var context = new ApplicationDbContext())
            {
                IQueryable<Dieta> Dietas;
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Dietas = DietasRepository.ReadDietas();
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
                return Dietas;
            }
        }

        public Dieta GetDieta(long id)
        {
            using (var context = new ApplicationDbContext())
            {
                Dieta Dieta;
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Dieta = DietasRepository.Read(id);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
                return Dieta;
            }
        }

        public void PutDieta(Dieta Dieta)
        {
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        DietasRepository.PutDieta(Dieta);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
            }
        }

        public Dieta Delete(long id)
        {
            Dieta resultado;
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        resultado = DietasRepository.Delete(id);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch(NoEncontradoException)
                    {
                        dbContextTransaction.Rollback();
                        throw;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
            }
            return resultado;
        }
    }
}
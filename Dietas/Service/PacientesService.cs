using Dietas.Models;
using Dietas.Repository;
using System;
using System.Linq;

namespace Dietas.Service
{
    public class PacientesService : IPacientesService
    {
        private IPacientesRepository PacientesRepository;
        public PacientesService(IPacientesRepository _PacientesRepository)
        {
            this.PacientesRepository = _PacientesRepository;
        }
        public Paciente Create(Paciente Paciente)
        {
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Paciente = PacientesRepository.Create(Paciente);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
                return Paciente;
            }
        }

        public IQueryable<Paciente> ReadPacientes()
        {
            using (var context = new ApplicationDbContext())
            {
                IQueryable<Paciente> Pacientes;
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Pacientes = PacientesRepository.ReadPacientes();
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
                return Pacientes;
            }
        }

        public Paciente GetPaciente(long id)
        {
            using (var context = new ApplicationDbContext())
            {
                Paciente Paciente;
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Paciente = PacientesRepository.Read(id);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
                return Paciente;
            }
        }

        public void PutPaciente(Paciente Paciente)
        {
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        PacientesRepository.PutPaciente(Paciente);
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

        public Paciente Delete(long id)
        {
            Paciente resultado;
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        resultado = PacientesRepository.Delete(id);
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
using System;
using System.Collections.Generic;
using System.Text;
using Anotaçoes.Models;
using Anotaçoes.Views;
using SQLite;

namespace Anotaçoes.Services
{
    public class ServicesDBNotas
    {
        SQLiteConnection con;
        public string StatusMessage { get; set; }
        public ServicesDBNotas(string dbPath)
        {
            if(dbPath == "") // verifica se o caminho para a db existe, caso não, ele cria
            {
                dbPath = App.dbPath;
            }
            con = new SQLiteConnection(dbPath); //define a conexão com o banco
            con.CreateTable<Notas>(); //cria a tabela notas com base no model Notas.cs
        }

        public void Inserir(Notas nota)
        {
            try
            {
                if (string.IsNullOrEmpty(nota.Titulo))
                    throw new Exception("Título da nota não informado");
                if (string.IsNullOrEmpty(nota.Dados))
                    throw new Exception("Dados da nota não informados");
                int result = con.Insert(nota);
                if (result != 0) 
                {
                this.StatusMessage = string.Format("{0} registro(s) adicionado(s): [Nota: {1}]", result, nota.Titulo);
                }
                else
                {
                    this.StatusMessage = string.Format("0 registro(s) adicionado(s)");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }
        public void Atualizar(Notas notas)
        {
            try
            {
                if (string.IsNullOrEmpty(notas.Titulo))
                    throw new Exception("Título da nota não informado");
                if (string.IsNullOrEmpty(notas.Dados))
                    throw new Exception("Dados da nota não informados");
                if (notas.Id <= 0)
                    throw new Exception("Id da nota não informado");
                con.Update(notas);
                int result = con.Update(notas);
                StatusMessage = string.Format("{0} Registro(s) alterado(s) com sucesso", result);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro> {0}:", ex.Message));
            }
        }

        public void Excluir(int id)
        {
            try
            {
                int result = con.Table<Notas>().Delete(reg=>reg.Id==id);
                StatusMessage = string.Format("{0} registros deletados.", result);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro> {0}:", ex.Message));
            }
        }

        public List<Notas> Localizar(string titulo)
        {
            List<Notas> lista = new List<Notas>();
            try
            {
                var resp = from p in con.Table<Notas>() 
                           where p.Titulo.ToLower().Contains(titulo.ToLower()) 
                           select p;
                lista = resp.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro> {0}:", ex.Message));
            }
            return lista;
        
        }
        public List<Notas> Localizar(string titulo, Boolean favoritos)
        {
            List<Notas> lista = new List<Notas>();
            try
            {
                var resp = from p in con.Table<Notas>() 
                           where p.Titulo.ToLower().Contains(titulo.ToLower())
                           && p.Favorito == favoritos
                           select p;
                lista = resp.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro> {0}:", ex.Message));
            }
            return lista;
        }
        public Notas GetNota(int id)
        {
            Notas m = new Notas();
            try 
            {
                m = con.Table<Notas>().First(n => n.Id == id);
                StatusMessage = string.Format("Nota {0} Encontrada", id);
            }
            catch (Exception ex) 
            {
                throw new Exception(string.Format("Erro> {0}:", ex.Message));
            }
            return m;
        }

    }
}

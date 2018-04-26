using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;
using System.Data;

namespace CamadaNegocio
{
    public class NCategoria
    {
        //metodo inserir
        public static string Inserir(string nome, string descricao)
        {
            DCategoria Obj = new DCategoria();
            Obj.Nome = nome;
            Obj.Descricao = descricao;
            return Obj.Inserir(Obj);
        }

        //metodo editar
        public static string Editar(int idcategoria, string nome, string descricao)
        {
            DCategoria Obj = new DCategoria();
            Obj.IdCategoria = idcategoria;
            Obj.Nome = nome;
            Obj.Descricao = descricao;
            return Obj.Editar(Obj);
        }

        //metodo deletar
        public static string Excluir(int idcategoria)
        {
            DCategoria Obj = new DCategoria();
            Obj.IdCategoria = idcategoria;
            return Obj.Excluir(Obj);
        }

        //metodo mostrar
        public static DataTable Mostar()
        {
            return new DCategoria().Mostrar();
        }

        //metodo Buscar Nome
        public static DataTable BuscarNome(string textobuscar)
        {
            DCategoria Obj = new DCategoria();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNome(Obj);
        }

    }
}

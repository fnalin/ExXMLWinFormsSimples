using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExXML
{
    class Pessoa
    {
        #region Atributos
        private int codigo;
        private string nome;
        private string telefone;
        #endregion

        #region Propriedades
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }


        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
        #endregion

        #region Métodos
        public static List<Pessoa> ListarPessoas()
        {
            var pessoas = new List<Pessoa>();
            var xml = XElement.Load("Pessoas.xml");
            foreach (XElement x in xml.Elements())
            {
                Pessoa p = new Pessoa()
                {
                    codigo = int.Parse(x.Attribute("codigo").Value),
                    nome = x.Attribute("nome").Value,
                    telefone = x.Attribute("telefone").Value
                };
                pessoas.Add(p);
            }
            return pessoas;
        }

        public static void AdicionarPessoa(Pessoa p)
        {
            var x = new XElement("pessoa");
            x.Add(new XAttribute("codigo", p.codigo.ToString()));
            x.Add(new XAttribute("nome", p.nome));
            x.Add(new XAttribute("telefone", p.telefone));
            var xml = XElement.Load("Pessoas.xml");
            xml.Add(x);
            xml.Save("Pessoas.xml");
        }

        public static void ExcluirPessoa(int codigo)
        {
            var xml = XElement.Load("Pessoas.xml");
            var x = xml.Elements().Where(p => p.Attribute("codigo").Value.Equals(codigo.ToString())).First();
            if (x != null)
            {
                x.Remove();
            }
            xml.Save("Pessoas.xml");
        }

        public static void EditarPessoa(Pessoa pessoa)
        {
            var xml = XElement.Load("Pessoas.xml");
            var x = xml.Elements().Where(p => p.Attribute("codigo").Value.Equals(pessoa.codigo.ToString())).First();
            if (x != null)
            {
                x.Attribute("nome").SetValue(pessoa.nome);
                x.Attribute("telefone").SetValue(pessoa.telefone);
            }
            xml.Save("Pessoas.xml");
        }

        #endregion
    }
}

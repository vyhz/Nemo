using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemo
{
    internal class clients
    {
		private int _idcli;
		private string _nomcli;
		private string _prenomcli;
		private string _niveaucli;

		public string NiveauCli
		{
			get { return _niveaucli; }
			set { _niveaucli = value; }
		}


		public string PrenomCli
		{
			get { return _prenomcli; }
			set { _prenomcli = value; }
		}


		public string NomCli
		{
			get { return _nomcli; }
			set { _nomcli = value; }
		}

		public int IdCli
		{
			get { return _idcli; }
			set { _idcli = value; }
		}

		public clients (int idcli, string nomcli, string prenomcli, string niveaucli)
		{
			_idcli = idcli;
			_nomcli = nomcli;
			_prenomcli = prenomcli;
			_niveaucli = niveaucli;


		}

        public override string ToString()
        {
            return Convert.ToString(_id);
        }
    }
}

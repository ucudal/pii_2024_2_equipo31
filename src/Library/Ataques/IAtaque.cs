using System;
using System.Collections.Generic;

namespace Library;

	public interface IAtaque
	{
		string Name{get;}
		double Daño {get; set; }
		string TipoAtaque { get; }
		void Ejecutar_Ataque (Pokemon oponente);
	}

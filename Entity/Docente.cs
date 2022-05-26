using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Docente
    {
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string TipoDocente { get; set; }
        public string AreaDesempenio { get; set; }
        public string Categoria { get; set; }
        public decimal Salario { get; set; }
        public decimal Nomina { get; set; }
        public string AreaInvestigacion { get; set; }
        public void CalcularSalario()
        {
            switch (Categoria.Replace(" ", String.Empty))
            {
                case "AuxiliardeTiempoCompleto":
                    Salario = 2645000;
                    break;
                case "AuxiliardeMedioTiempo":
                    Salario = 1509000;
                    break;
                case "AsistentedeMedioTiempo":
                    Salario = 3125000;
                    break;
                case "AsistentedeTiempoCompleto":
                    Salario = 1749000;
                    break;
                case "AsociadodeTiempoCompleto":
                    Salario = 3606000;
                    break;
                case "AsociadodeMedioTiempo":
                    Salario = 1990000;
                    break;
                case "TitulardeTiempoCompleto":
                    Salario = 3918000;
                    break;
                case "TitulardeMedioTiempo":
                    Salario = 2146000;
                    break;
                default:
                    Salario = 0.0m;
                    break;
            }
        }
        public void CalcularNomina()
        {
            switch (AreaDesempenio.Replace(" ", String.Empty)
                )
            {
                case "Especializacion":
                    Nomina = Salario + (Salario * 0.10m);
                    break;
                case "Maestria":
                    Nomina = Salario + (Salario * 0.45m);
                    break;
                case "Doctorado":
                    Nomina = Salario + (Salario * 0.90m);
                    break;
                case "PostDoctorado":
                    Nomina = Salario + (0);
                    break;
                default: 
                    Nomina = 0.0m;
                    break;
            }
        }
        public void CalcularVinculacionProyecto()
        {
            switch (AreaInvestigacion)
            {
                case "A1":
                    Nomina = Salario + (Salario * 0.56m);
                    break;
                case "A":
                    Nomina = Salario + (Salario * 0.47m);
                    break;
                case "B":
                    Nomina = Salario + (Salario * 0.42m);
                    break;
                case "C":
                    Nomina = Salario + (Salario * 0.38m);
                    break;
                case "Colciencias":
                    Nomina = Salario + (Salario * 0.33m);
                    break;
                case "Semillero":
                    Nomina = Salario + (Salario * 0.19m);
                    break;
                default:
                    Nomina = 0.0m;
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ISW123_ReporteroDigital_2023_4374
{



    public class ExcepcionReportero : Exception
    {
        public string RecursoFallido { get; }
        public ExcepcionReportero(string message, string recurso) : base(message)
        {
            RecursoFallido = recurso;
        }
    }


    public class GestorNoticias
    {


        public event Action<string>? OnIniciando;
        public event Action<string>? OnFinalizado;



        public async Task<string> DescargarTextoAsycn()
        {

            OnIniciando?.Invoke("Tamo decargando la vaina");

            Console.WriteLine("Descargando...");
            await Task.Delay(2000);

            OnFinalizado?.Invoke("Pa, ya se decargo.");
            return "Texto descargado.";

        }

        public async Task<string> DescargarImagenAsync()
        {
            OnIniciando?.Invoke("cargando...");

            Console.WriteLine("Descargando imagen...");
            await Task.Delay(3000);

            OnFinalizado?.Invoke("Descarga de imagen nitida.");
            return "[Foto_Goku.jpg, Foto_Naruto.png]";
        }

        public async Task<string> DescargarEstadisticasAsycn(bool explotar)
        {
            OnIniciando?.Invoke("Los Datos de Analisis...");

            Console.WriteLine("Descargando estadisticas...");
            await Task.Delay(1500);

            if (explotar)
            {
                throw new ExcepcionReportero("Se callo el sistema");
            }

            OnFinalizado?.Invoke("Estadisticas listas.");
            return "Visitas: 1500, Likes: 300, Shares: 75";
        }




    }






}


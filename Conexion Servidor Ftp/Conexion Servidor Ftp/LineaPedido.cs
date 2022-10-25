using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion_Servidor_Ftp
{
    public class LineaPedido
    {
        string Peso = "0";

        public LineaPedido(String numero, String referencia, String fecha, Entrega entrega, String proveedor, Bulto bulto, Notas nota, String retorno)
        {
            NumeroPedido = numero;
            ReferenciaPedido = referencia;
            FechaPedido = fecha;
            Entrega = entrega;
            NombreProveedor = proveedor;
            Bulto = bulto;
            if (nota == null)
            {
                Nota = new Notas();
                Nota.Tipo = "0";
            }
            else
                Nota = nota;

            Retorno = retorno;
        }

        public String NumeroPedido { get; set; }

        public String ReferenciaPedido { get; set; }

        public String FechaPedido { get; set; }

        public Entrega Entrega { get; set; }

        public String NombreProveedor { get; set; }

        public Bulto Bulto { get; set; }

        public Notas Nota { get; set; }

        public String Retorno { get; set; }

        public String toCSV()
        {
            var newLine = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};{16};{17};{18}",
                NumeroPedido,
                ReferenciaPedido,
                FechaPedido,
                Entrega.Nombre,
                Entrega.Direccion,
                Entrega.Ciudad,
                Entrega.Cp,
                Entrega.Email,
                Entrega.Telefonos.FirstOrDefault(),
                NombreProveedor,
                "1",
                Bulto.Volumen,
                Peso = ObtenerPeso(Bulto.CodigoAgencia),
                Bulto.Etiqueta,
                Bulto.Referencia,
                Bulto.Descripcion,
                Bulto.Agencia,
                Bulto.CodigoAgencia,
                Nota.Valor.FirstOrDefault()
            );

            return newLine;

        }
        //
        //FUNCIÓN PARA OBTENER EL PESO DEL BULTO DEPENDIENDO DEL VALOR DEL CÓDIGO DE TARIFA
        //
        public string ObtenerPeso(string codigo_agencia)
        {
            switch (codigo_agencia)
            {
                case "EN000000000":
                    Peso = "0";
                    break;
                case "EN000000001":
                    Peso = "4";
                    break;
                case "EN000000002":
                    Peso = "4";
                    break;
                case "EN000000003":
                    Peso = "2";
                    break;
                case "EN000000004":
                    Peso = "2";
                    break;
                case "EN000000005":
                    Peso = "2";
                    break;
                case "EN000000006":
                    Peso = "8";
                    break;
                case "EN000000007":
                    Peso = "8";
                    break;
                case "EN000000008":
                    Peso = "8";
                    break;
                case "EN000000009":
                    Peso = "8";
                    break;
                case "EN000000010":
                    Peso = "14";
                    break;
                case "EN000000011":
                    Peso = "20";
                    break;
                case "EN000000012":
                    Peso = "20";
                    break;
                case "EN000000013":
                    Peso = "25";
                    break;
                case "EN000000014":
                    Peso = "19";
                    break;
                case "EN000000015":
                    Peso = "20";
                    break;
                case "EN000000016":
                    Peso = "5";
                    break;
                case "EN000000017":
                    Peso = "18";
                    break;
                case "EN000000018":
                    Peso = "10";
                    break;
                case "EN000000019":
                    Peso = "0";
                    break;
                case "EN000000020":
                    Peso = "10";
                    break;
                case "EN000000021":
                    Peso = "2";
                    break;
                case "EN000000022":
                    Peso = "8";
                    break;
                case "EN000000023":
                    Peso = "10";
                    break;
                case "EN000000024":
                    Peso = "10";
                    break;
                case "EN000000025":
                    Peso = "14";
                    break;
                case "EN000000026":
                    Peso = "29";
                    break;
                case "EN000000027":
                    Peso = "2";
                    break;
                case "EN000000028":
                    Peso = "20";
                    break;
                case "EN000000029":
                    Peso = "25";
                    break;
                case "EN000000034":
                    Peso = "25";
                    break;
                case "EN000000035":
                    Peso = "15";
                    break;
                case "EN000000036":
                    Peso = "30";
                    break;
                case "EN000000037":
                    Peso = "24";
                    break;
                case "EN000000038":
                    Peso = "24";
                    break;
                case "EN000000039":
                    Peso = "16";
                    break;
                case "EN000000040":
                    Peso = "14";
                    break;
                case "EN000000041":
                    Peso = "28";
                    break;
            }
            return Peso;
        }
    }
}

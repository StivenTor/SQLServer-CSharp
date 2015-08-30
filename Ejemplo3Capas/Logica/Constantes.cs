using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Constantes
    {
        public static String instancia = "Data Source=STIVEN;Initial Catalog=agenda;Integrated Security=True"; 
        public static String pro_crear_persona = "exec crear_persona";
        public static String pro_modificar_persona = "exec modificar_persona";
        public static String pro_traer_persona = "exec traer_persona";
        public static String pro_borrar_id = "exec borrarId";
    }
}

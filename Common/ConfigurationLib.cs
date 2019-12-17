using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class ConfigurationLib
    {
      public static  int CodigoExito { get { return 200;}}
      public static  string MensajeExitoES { get{ return "Operación Exitosa";}}      
      public static  int CodigoErrorNoDataFound { get{ return 201;}}
      public static  string NoDataFoundES { get{ return "No hay data encontrada";}}      
     
      public static  int CodigoLogin { get{ return 202;}}
      public static  string MensajeLoginES { get{ return "Usuario y password incorrecto";}}
      
      public static  int CodigoExisteUsuario { get{ return 203;}}
      public static  string MensajeExisteUsuarioES { get{ return "El usuario ya existe";}}
      
      public static  int CodigoParametrosNoValido { get{ return 204;}}      
      public static  string MensajeParametrosNoValidoES { get{ return "Parámetros Ingresos Incorrectos";}}
     

      
      public static  int CodigoErrorBD { get{ return 501;}}      
      public static  string MensajeErrorBDES { get{ return "Error de conexión";}}
      
      public static  int CodigoErrorTimeOut { get{ return 502;}}
      public static  string MensajeErrorTimeOutES { get{ return "Error de tiempo de espera";}}
      
     
      public static  int CodigoErrorNoEspecificado { get{ return 500;}}
      
      public static  string MensajeErrorNoEspecificadoES { get{ return "Error no especificado";}}
     
      public static  int CodigoErrorNoFound { get{ return 400;}}      
      public static  string MensajeErrorNoFoundES { get{ return "Error No encontrado";}}
    
      public static  int CodigoErrorNoAuthorized { get{ return 401;}}      
      public static  string MensajeErrorNoAuthorizedES { get{ return "No Autorizado";}}

     

    }
}

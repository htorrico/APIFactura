using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Common
{
   
        public class UtilitariesResponse<T> where T : class, new()
        {
            /*private IConfigurationLib ConfigurationLib = null;*/

            //public UtilitariesResponse(IConfigurationLib _configurationLib)
            //{
            //    ConfigurationLib = _configurationLib;
            //}

            public ResponseBase<T> setResponseBaseForExecuteSQLCommand(int result)
            {
                ResponseBase<T> response = new ResponseBase<T>();
                if (result >= 0)
                {
                    response.Code = ConfigurationLib.CodigoExito;
                    response.Message = ConfigurationLib.MensajeExitoES;                    
                }
                else
                {
                    response.Code = ConfigurationLib.CodigoErrorNoDataFound;
                    response.Message = ConfigurationLib.NoDataFoundES;                    
                }
                return response;
            }
            public ResponseBase<T> setResponseBaseForList(IQueryable<T> query)
            {
                ResponseBase<T> response = new ResponseBase<T>();
                if (query == null)
                {
                    response.Code = ConfigurationLib.CodigoErrorNoDataFound;
                    response.Message = ConfigurationLib.NoDataFoundES;                    
                }
                else
                {
                    if (query.Any())
                    {
                        response.Code = ConfigurationLib.CodigoExito;
                        response.Message = ConfigurationLib.MensajeExitoES;                        
                        response.listado = query.ToList();
                        response.IsResultList = true;
                    }
                    else
                    {
                        response.Code = ConfigurationLib.CodigoErrorNoDataFound;
                        response.Message = ConfigurationLib.NoDataFoundES;                        
                    }
                }
                return response;
            }
            public ResponseBase<T> setResponseBaseForObj(T obj)
            {
                ResponseBase<T> response = new ResponseBase<T>();
                if (obj != null)
                {
                    response.Code = ConfigurationLib.CodigoExito;
                    response.Message = ConfigurationLib.MensajeExitoES;                    
                    response.objeto = obj;
                }
                else
                {
                    response.Code = ConfigurationLib.CodigoErrorNoDataFound;
                    response.Message = ConfigurationLib.NoDataFoundES;                    
                }
                return response;
            }

            public ResponseBase<T> setResponseBaseForValidationExceptionString(IList<string> errors)
            {
                ResponseBase<T> response = new ResponseBase<T>();
                response.Code = ConfigurationLib.CodigoParametrosNoValido;
                response.Message = ConfigurationLib.MensajeParametrosNoValidoES;                
                response.FunctionalErrors = errors.ToList();
                return response;
            }
            public ResponseBase<T> setResponseBaseForOK()
            {
                ResponseBase<T> response = new ResponseBase<T>();
                response.Code = ConfigurationLib.CodigoExito;
                response.Message = ConfigurationLib.MensajeExitoES;                
                return response;
            }
            public ResponseBase<T> setResponseBaseForOK(T obj)
            {
                ResponseBase<T> response = new ResponseBase<T>();
                response.Code = ConfigurationLib.CodigoExito;
                response.Message = ConfigurationLib.MensajeExitoES;
                if (obj != null) response.objeto = obj;
                return response;
            }
            public ResponseBase<T> setResponseBaseForOK(IEnumerable<T> obj)
            {
                ResponseBase<T> response = new ResponseBase<T>();
                response.Code = ConfigurationLib.CodigoExito;
                response.Message = ConfigurationLib.MensajeExitoES;
                if (obj.Any()) { response.listado = obj; response.IsResultList = true; }
                return response;
            }
            public ResponseBase<T> setResponseBaseForExceptionUnexpected()
            {
                ResponseBase<T> response = new ResponseBase<T>();
                response.Code = ConfigurationLib.CodigoErrorNoEspecificado;
                response.Message = ConfigurationLib.MensajeErrorNoEspecificadoES;
                return response;
            }
            public ResponseBase<T> setResponseBaseForException(Exception ex)
            {
                ResponseBase<T> response = new ResponseBase<T>();
                if (ex is TimeoutException)
                {
                    response.Code = ConfigurationLib.CodigoErrorTimeOut;
                    response.Message = ConfigurationLib.MensajeErrorTimeOutES;
                }
                else if (ex is HttpRequestException)
                {
                    response.Code = ConfigurationLib.CodigoErrorTimeOut;
                    response.Message = ConfigurationLib.MensajeErrorTimeOutES;
                }
                else if (ex is WSNotAuthorized)
                {
                    response.Code = ConfigurationLib.CodigoErrorNoAuthorized;
                    response.Message = ConfigurationLib.MensajeErrorNoAuthorizedES;
                }
                else if (ex is WSNotFoundException)
                {
                    response.Code = ConfigurationLib.CodigoErrorNoFound;
                    response.Message = ConfigurationLib.MensajeErrorNoFoundES;
                }
                else
                {
                    response.Code = ConfigurationLib.CodigoErrorNoEspecificado;
                    response.Message = ConfigurationLib.MensajeErrorNoEspecificadoES;
                }
                response.TechnicalErrors = ex;
                return response;
            }
            public ResponseBase<T> setResponseBaseForNoAuthorized()
            {
                ResponseBase<T> response = new ResponseBase<T>();
                response.Code = ConfigurationLib.CodigoErrorNoAuthorized;
                response.Message = ConfigurationLib.MensajeErrorNoAuthorizedES;
                response.listado = new List<T>();
                return response;
            }
        //public ResponseBase<T> setResponseBaseForNoAuthorized(TokenErrorResponse error)
        //{
        //    ResponseBase<T> response = new ResponseBase<T>();
        //    response.Code = ConfigurationLib.CodigoErrorNoAuthorized;
        //    response.Message = ConfigurationLib.MensajeErrorNoAuthorizedES;
        //    response.MessageEN = ConfigurationLib.MensajeErrorNoAuthorizedEN;
        //    response.listado = new List<T>();
        //    var errorResponse = new List<string>();
        //    errorResponse.Add(error.ErrorDescription);
        //    response.FunctionalErrors = errorResponse;
        //    return response;
        //}
        public ResponseBase<T> setResponseBaseForNoDataFound()
            {
                ResponseBase<T> response = new ResponseBase<T>();
                response.Code = ConfigurationLib.CodigoErrorNoDataFound;
                response.Message = ConfigurationLib.NoDataFoundES;
                response.listado = new List<T>();
                return response;
            }
            public ResponseBase<T> setResponseBaseForParameterNoValid()
            {
                ResponseBase<T> response = new ResponseBase<T>();
                response.Code = ConfigurationLib.CodigoParametrosNoValido;
                response.Message = ConfigurationLib.MensajeParametrosNoValidoES;
                response.listado = new List<T>();
                return response;
            }
        }
   
}

using CapaEntidades;
using System.Web.SessionState;

namespace CapaPresentacion.Custom
{
    public class SessionManager
    {
        #region variables
        private HttpSessionState _currentSession;
        #endregion

        public SessionManager(HttpSessionState session)
        {
            this._currentSession = session;
        }

        #region metodos
        private HttpSessionState CurrentSession
        {
            get { return this._currentSession; }
        }

        public string UserSessionId
        {
            set { CurrentSession["UserSessionId"] = value; }
            get { return (string)CurrentSession["UserSessionId"]; }
        }


        public Usuario UserSessionUsuario
        {
            set { CurrentSession["UserSessionUsuario"] = value; }
            get { return (Usuario)CurrentSession["UserSessionUsuario"]; }
        }

        #endregion
    }
}
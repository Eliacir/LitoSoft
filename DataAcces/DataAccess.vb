Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Data
Imports CapaEntidades



Public Class DataAccess

#Region "LITOGRAFIA"
    Public Sub EliminarCliente(IdCliente As Integer, IdLitografia As Int32)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "EliminarCliente"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdCliente", DbType.Int32, IdCliente)
        DB.AddInParameter(DatabaseCommand, "IdLitografia", DbType.Int32, IdLitografia)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Sub
    Public Function RecuperarClientesPorFiltro(ByVal Filtro As Int32, ByVal Texto As String) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "RecuperarClientesPorFiltro"
        Dim dbCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)

        db.AddInParameter(dbCommand, "Filtro", DbType.Int32, Filtro)
        db.AddInParameter(dbCommand, "Texto", DbType.String, Texto)

        Using connection As DbConnection = db.CreateConnection()
            connection.Open()
            Try
                Return db.ExecuteDataSet(dbCommand)
            Catch ex As Exception
                Throw ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function ActualizarCliente(ByVal Nombre As String, ByVal Documento As String, ByVal Direccion As String, IdCliente As Int32, ByVal Telefono As String, ByVal Idlitografia As Int32) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "ActualizarCliente"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "Nombre", DbType.String, Nombre)
        DB.AddInParameter(DatabaseCommand, "Documento", DbType.String, Documento)
        DB.AddInParameter(DatabaseCommand, "Direccion", DbType.String, Direccion)
        DB.AddInParameter(DatabaseCommand, "IdCliente", DbType.Int32, IdCliente)
        DB.AddInParameter(DatabaseCommand, "Telefono", DbType.String, Telefono)
        DB.AddInParameter(DatabaseCommand, "IdLitografia", DbType.String, Idlitografia)
        Dim rpta As String
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                rpta = If(DB.ExecuteNonQuery(DatabaseCommand) = 1, "ok", "El Registro No pudo ser insertado")
                Return rpta
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function InsertarCliente(ByVal Nombre As String, ByVal Documento As String, ByVal Direccion As String, ByVal Telefono As String, ByVal Idlitografia As Int32) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarCliente"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "Nombre", DbType.String, Nombre)
        DB.AddInParameter(DatabaseCommand, "Documento", DbType.String, Documento)
        DB.AddInParameter(DatabaseCommand, "Direccion", DbType.String, Direccion)
        DB.AddInParameter(DatabaseCommand, "Telefono", DbType.String, Telefono)
        DB.AddInParameter(DatabaseCommand, "IdLitografia", DbType.String, Idlitografia)
        Dim rpta As String
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                rpta = If(DB.ExecuteNonQuery(DatabaseCommand) = 1, "ok", "El Registro No pudo ser insertado")
                Return rpta
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function


    Public Function RecuperarClientes(ByVal Idlitografia As Int32) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "RecuperarClientes"
        Dim dbCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)
        db.AddInParameter(dbCommand, "IdLitografia", DbType.String, Idlitografia)
        Using connection As DbConnection = db.CreateConnection()
            connection.Open()
            Try
                Return db.ExecuteDataSet(dbCommand)
            Catch ex As Exception
                Throw ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarParametro(nombre As String, idlitografia As Int32) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "Recuperarparametro"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)
        DB.AddInParameter(DatabaseCommand, "Nombre", DbType.String, nombre)
        DB.AddInParameter(DatabaseCommand, "IdLitografia", DbType.String, idlitografia)
        Dim rpta As String
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                rpta = CType(DB.ExecuteScalar(DatabaseCommand), String)
                Return rpta
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function


    Public Function RecuperarPapel(idLitografia As Integer) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "RecuperarPapel"
        Dim dbCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)

        db.AddInParameter(dbCommand, "IdLitografia", DbType.Int32, idLitografia)

        Using connection As DbConnection = db.CreateConnection()
            connection.Open()
            Try
                Return db.ExecuteDataSet(dbCommand)
            Catch ex As Exception
                Throw ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarCorte() As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "RecuperarCorte"
        Dim dbCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)
        Using connection As DbConnection = db.CreateConnection()
            connection.Open()
            Try
                Return db.ExecuteDataSet(dbCommand)
            Catch ex As Exception
                Throw ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarMontaje(idCorte As Integer) As String
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "RecuperarMontaje"
        Dim dbCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)

        db.AddInParameter(dbCommand, "IdCorte", DbType.Int32, idCorte)

        Using connection As DbConnection = db.CreateConnection()
            connection.Open()
            Try
                Return db.ExecuteScalar(dbCommand).ToString()
            Catch ex As Exception
                Throw ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Sub ActualizarLitografia(idLitografia As Integer, nombre As String, direccion As String, telefono As String, imagen() As Byte, Nombreusuario As String, Clave As String, Estado As Boolean)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "ActualizarLitografia"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdLitografia", DbType.Int32, idLitografia)
        DB.AddInParameter(DatabaseCommand, "Nombre", DbType.String, nombre)
        DB.AddInParameter(DatabaseCommand, "Telefono", DbType.String, telefono)
        DB.AddInParameter(DatabaseCommand, "Direccion", DbType.String, direccion)
        DB.AddInParameter(DatabaseCommand, "Logo", DbType.Binary, imagen)
        DB.AddInParameter(DatabaseCommand, "Usuario", DbType.String, Nombreusuario)
        DB.AddInParameter(DatabaseCommand, "Clave", DbType.String, Clave)
        DB.AddInParameter(DatabaseCommand, "Estado", DbType.String, Estado)
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)

            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    Public Sub InactivarLitografia(IdLitografia As Integer)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InactivarLitografia"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdLitografia", DbType.Int32, IdLitografia)
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    Public Function RecuperarLitografias() As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "RecuperarLitografias"

        Dim dbCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)
        Using connection As DbConnection = db.CreateConnection()
            connection.Open()
            Try
                Return db.ExecuteDataSet(dbCommand)
            Catch ex As Exception
                Throw ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function


    Public Function RecuperarLitografiasPorNombre(texto As String) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "RecuperarLitografiasPorNombre"
        Dim dbCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)

        db.AddInParameter(dbCommand, "Nombre", DbType.String, texto)

        Using connection As DbConnection = db.CreateConnection()
            connection.Open()
            Try
                Return db.ExecuteDataSet(dbCommand)
            Catch ex As Exception
                Throw ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarLitografiaPorIdLitografia(idLitografia As Short) As IDataReader
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarLitografiasPorIdLitografia"
        Dim dbCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(dbCommand, "IdLitografia", DbType.Int16, idLitografia)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteReader(dbCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Sub InsertarLitografia(nombre As String, direccion As String, telefono As String, imagen() As Byte, Nombreusuario As String, Clave As String, Estado As Boolean)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarLitografia"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "Nombre", DbType.String, nombre)
        DB.AddInParameter(DatabaseCommand, "Telefono", DbType.String, telefono)
        DB.AddInParameter(DatabaseCommand, "Direccion", DbType.String, direccion)
        DB.AddInParameter(DatabaseCommand, "Logo", DbType.Binary, imagen)
        DB.AddInParameter(DatabaseCommand, "Usuario", DbType.String, Nombreusuario)
        DB.AddInParameter(DatabaseCommand, "Clave", DbType.String, Clave)
        DB.AddInParameter(DatabaseCommand, "Estado", DbType.String, Estado)
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    Public Function RecuperarUsuario(ByVal NomUsuario As String, ByVal clave As String) As IDataReader
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarUsuario"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "usuario", DbType.String, NomUsuario)
        DB.AddInParameter(DatabaseCommand, "clave", DbType.String, clave)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteReader(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function
#End Region


#Region "Sistema Web"
    Public Function RecuperarDetalleCotizacionPorFiltro(filtro As Integer, texto As String) As Object
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "RecuperarDetalleCotizacionPorFiltro"
        Dim dbCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)

        db.AddInParameter(dbCommand, "Filtro", DbType.Int32, filtro)
        db.AddInParameter(dbCommand, "Texto", DbType.String, texto)

        Using connection As DbConnection = db.CreateConnection()
            connection.Open()
            Try
                Return db.ExecuteDataSet(dbCommand)
            Catch ex As Exception
                Throw ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarDetalleCotizacion(idCotizacion As Int32) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "RecuperarDetalleCotizacion"
        Dim dbCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)


        db.AddInParameter(dbCommand, "IdCotizacion", DbType.Int32, idCotizacion)

        Using connection As DbConnection = db.CreateConnection()
            connection.Open()
            Try
                Return db.ExecuteDataSet(dbCommand)
            Catch ex As Exception
                Throw ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function
    Public Function RecuperarCotizaciones() As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "RecuperarCotizaciones"

        Dim dbCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)
        Using connection As DbConnection = db.CreateConnection()
            connection.Open()
            Try
                Return db.ExecuteDataSet(dbCommand)
            Catch ex As Exception
                Throw ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function
    Public Function RecuperarCotizacionesPorFiltro(filtro As Integer, texto As String) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "RecuperarCotizacionesPorFiltro"
        Dim dbCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)

        db.AddInParameter(dbCommand, "Filtro", DbType.Int32, filtro)
        db.AddInParameter(dbCommand, "Texto", DbType.String, texto)

        Using connection As DbConnection = db.CreateConnection()
            connection.Open()
            Try
                Return db.ExecuteDataSet(dbCommand)
            Catch ex As Exception
                Throw ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarEmpleados() As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "RecuperarEmpleados"

        Dim dbCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)
        Using connection As DbConnection = db.CreateConnection()
            connection.Open()
            Try
                Return db.ExecuteDataSet(dbCommand)
            Catch ex As Exception
                Throw ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarEmpleadosPorFiltro(filtro As Integer, texto As String) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "RecuperarEmpleadosPorFiltro"
        Dim dbCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)

        db.AddInParameter(dbCommand, "Filtro", DbType.Int32, filtro)
        db.AddInParameter(dbCommand, "Texto", DbType.String, texto)

        Using connection As DbConnection = db.CreateConnection()
            connection.Open()
            Try
                Return db.ExecuteDataSet(dbCommand)
            Catch ex As Exception
                Throw ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function



    Public Function RecuperarProyectosPorNombre(text As String) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "RecuperarProyectosPorNombre"
        Dim dbCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)

        db.AddInParameter(dbCommand, "Texto", DbType.String, text)
        Using connection As DbConnection = db.CreateConnection()
            connection.Open()
            Try
                Return db.ExecuteDataSet(dbCommand)
            Catch ex As Exception
                Throw ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function



    Public Sub EliminarDetalleCotizacion(IdDetalleCotizacion As Integer)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "EliminarDetalleCotizacion"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdDetalleCotizacion", DbType.Int32, IdDetalleCotizacion)
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Sub
    Public Sub EliminarDetalleProyecto(IdDetalleProyecto As Integer)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "EliminarDetalleProyecto"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdDetalleProyecto", DbType.Int32, IdDetalleProyecto)
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Sub
    Public Sub EliminarManoObra(IdManoObra As Integer)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "EliminarManoObra"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdManoObra", DbType.Int32, IdManoObra)
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    Public Sub EliminarEmpleado(IdEmpleado As Integer)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "EliminarEmpleado"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdEmpleado", DbType.Int32, IdEmpleado)
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    Public Sub EliminarImagenesPorProyecto(IdProyecto As Integer)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "EliminarImagenesPorProyecto"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdProyecto", DbType.Int32, IdProyecto)
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    Public Sub EliminarProyecto(IdProyecto As Integer)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "EliminarProyecto"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdProyecto", DbType.Int32, IdProyecto)
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Sub
    Public Sub EliminarCotizacion(IdCotizacion As Integer)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "EliminarCotizacion"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdCotizacion", DbType.Int32, IdCotizacion)
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    Public Function RecuperarDetalleCotizacionPorIdDetalleCotizacion(ByVal IdDetalleCotizacion As Int32) As IDataReader
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarDetalleCotizacionPorIdDetalleCotizacion"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)
        DB.AddInParameter(DatabaseCommand, "IdDetalleCotizacion", DbType.Int32, IdDetalleCotizacion)
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteReader(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Sub ActualizarDetalleCotizacion(ByVal IdDetalleCotizacion As Int32, ByVal Descripcion As String, Cantidad As String, Valor As Decimal)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "ActualizarDetalleCotizacion"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdDetalleCotizacion", DbType.Int32, IdDetalleCotizacion)
        DB.AddInParameter(DatabaseCommand, "Descripcion", DbType.String, Descripcion)
        DB.AddInParameter(DatabaseCommand, "Cantidad", DbType.String, Cantidad)
        DB.AddInParameter(DatabaseCommand, "ValorUnitario", DbType.String, Valor)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Sub


    Public Sub InsertarDetalleCotizacion(ByVal IdCotizacion As Int32, ByVal Descripcion As String, Cantidad As String, Valor As Decimal)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarDetalleCotizacion"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)
        DB.AddInParameter(DatabaseCommand, "IdCotizacion", DbType.Int32, IdCotizacion)
        DB.AddInParameter(DatabaseCommand, "Descripcion", DbType.String, Descripcion)
        DB.AddInParameter(DatabaseCommand, "Cantidad", DbType.String, Cantidad)
        DB.AddInParameter(DatabaseCommand, "ValorUnitario", DbType.Decimal, Valor)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    Public Function recuperarCotizacionPorIdCotizacion(ByVal IdCotizacion As Int32) As IDataReader
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarCotizacionesPorIdCotizacion"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)
        DB.AddInParameter(DatabaseCommand, "IdCotizacion", DbType.Int32, IdCotizacion)
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteReader(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function


    Public Function RecuperarImagenReporteCotizacion(ByVal IdCotizacion As Int32) As IDataReader
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarImagenReporteCotizacion"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)
        DB.AddInParameter(DatabaseCommand, "IdCotizacion", DbType.Int32, IdCotizacion)
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteReader(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function



    Public Function InsertarCotizacion(ByVal CodigoCotizacion As String, ByVal IdProyecto As Int32, ByVal ValidezOferta As String, ByVal TiempoEntrega As String, ByVal LugarEntrega As String, ByVal Garantia As String, ByVal Nota As String, ByVal AlcancePropuesta As String) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarCotizacion"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "CodigoCotizacion", DbType.String, CodigoCotizacion)
        DB.AddInParameter(DatabaseCommand, "IdProyecto", DbType.String, IdProyecto)
        DB.AddInParameter(DatabaseCommand, "ValidezOferta", DbType.String, ValidezOferta)
        DB.AddInParameter(DatabaseCommand, "TiempoEntrega", DbType.String, TiempoEntrega)
        DB.AddInParameter(DatabaseCommand, "LugarEntrega", DbType.String, LugarEntrega)
        DB.AddInParameter(DatabaseCommand, "Garantia", DbType.String, Garantia)
        DB.AddInParameter(DatabaseCommand, "Nota", DbType.String, Nota)
        DB.AddInParameter(DatabaseCommand, "AlcancePropuesta", DbType.String, AlcancePropuesta)

        Dim rpta As String
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                rpta = If(DB.ExecuteNonQuery(DatabaseCommand) = 1, "ok", "El Registro No pudo ser insertado")
                Return rpta
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function ActualizarCotizacion(ByVal IdCotizacion As Int32, ByVal CodigoCotizacion As String, ByVal IdProyecto As Int32, ByVal ValidezOferta As String, ByVal TiempoEntrega As String, ByVal LugarEntrega As String, ByVal Garantia As String, ByVal Nota As String,
       ByVal AlcancePropuesta As String) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "ActualizarCotizacion"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdCotizacion", DbType.Int32, IdCotizacion)
        DB.AddInParameter(DatabaseCommand, "CodigoCotizacion", DbType.String, CodigoCotizacion)
        DB.AddInParameter(DatabaseCommand, "IdProyecto", DbType.String, IdProyecto)
        DB.AddInParameter(DatabaseCommand, "ValidezOferta", DbType.String, ValidezOferta)
        DB.AddInParameter(DatabaseCommand, "TiempoEntrega", DbType.String, TiempoEntrega)
        DB.AddInParameter(DatabaseCommand, "LugarEntrega", DbType.String, LugarEntrega)
        DB.AddInParameter(DatabaseCommand, "Garantia", DbType.String, Garantia)
        DB.AddInParameter(DatabaseCommand, "Nota", DbType.String, Nota)
        DB.AddInParameter(DatabaseCommand, "AlcancePropuesta", DbType.String, AlcancePropuesta)

        Dim rpta As String
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                rpta = If(DB.ExecuteNonQuery(DatabaseCommand) = 1, "ok", "El Registro No pudo ser insertado")
                Return rpta
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function


    Public Function RecuperarManoObraPorIdProyecto(ByVal IdProyecto As Int16) As DataSet
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarManoObraPorIdProyecto"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdProyecto", DbType.String, IdProyecto)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteDataSet(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarDetalleProyectoPorIdProyecto(ByVal IdProyecto As Int16) As DataSet
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarDetalleProyectoPorIdProyecto"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdProyecto", DbType.String, IdProyecto)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteDataSet(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarProyectosPorEmpleado(ByVal IdEmpleado As Int16) As DataSet
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarProyectosPorEmpleado"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdEmpleado", DbType.String, IdEmpleado)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteDataSet(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarProyectosPorIdProyectoReader(ByVal IdProyecto As Int16) As IDataReader
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarProyectosPorIdProyecto"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdProyecto", DbType.Int16, IdProyecto)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteReader(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarEmpleadoPorIdEmpleado(ByVal IdEmpleado As Int16) As IDataReader
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarEmpleadoPorIdEmpleado"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdEmpleado", DbType.Int16, IdEmpleado)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteReader(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarDetalleProyectoPorIdDetalleProyecto(ByVal IdDetalleProyecto As Int16) As IDataReader
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarDetalleProyectoPorIdDetalleProyecto"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdDetalleProyecto", DbType.Int16, IdDetalleProyecto)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteReader(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function
    Public Function RecuperarManoObraPorIdManoObra(ByVal IdManoObra As Int16) As IDataReader
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarManoObraPorIdManoObra"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdManoObra", DbType.Int16, IdManoObra)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteReader(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarClientePorIdcliente(ByVal IdCliente As Int16, ByVal IdLitografia As Int32) As IDataReader
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarClientePorIdcliente"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdCliente", DbType.Int16, IdCliente)
        DB.AddInParameter(DatabaseCommand, "IdLitografia", DbType.Int16, IdLitografia)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteReader(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarProyectosPorIdProyecto(ByVal IdProyecto As Int16) As DataSet
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarProyectosPorIdProyecto"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdProyecto", DbType.String, IdProyecto)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteDataSet(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarProyectos() As DataSet
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarProyectos"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteDataSet(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    'oEmpresa.Nombre, oEmpresa.Ruc, oEmpresa.Direccion, oEmpresa.Telefono, oEmpresa.Correo, oEmpresa.Logo
    Public Function InsertarEmpresa(ByVal Nombre As String, ByVal Ruc As String, ByVal Direcion As String, ByVal Telefono As String, ByVal Correo As String) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarEmpresa"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "Nombre", DbType.String, Nombre)
        DB.AddInParameter(DatabaseCommand, "Ruc", DbType.String, Ruc)
        DB.AddInParameter(DatabaseCommand, "Direccion", DbType.String, Direcion)
        DB.AddInParameter(DatabaseCommand, "Telefono", DbType.String, Telefono)
        DB.AddInParameter(DatabaseCommand, "Correo", DbType.String, Correo)

        Dim rpta As String
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                'Ejecuta el Procedimiento Almacenado
                rpta = If(DB.ExecuteNonQuery(DatabaseCommand) = 1, "ok", "El Registro No pudo ser insertado")
                Return rpta
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    'oEmpresa.Nombre, oEmpresa.Ruc, oEmpresa.Direccion, oEmpresa.Telefono, oEmpresa.Correo, oEmpresa.Logo
    Public Function ActualizarEmpresa(ByVal IdEmpresa As Int32, ByVal Nombre As String, ByVal Ruc As String, ByVal Direcion As String, ByVal Telefono As String, ByVal Correo As String) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "ActualizarEmpresa"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdEmpresa", DbType.Int32, IdEmpresa)
        DB.AddInParameter(DatabaseCommand, "Nombre", DbType.String, Nombre)
        DB.AddInParameter(DatabaseCommand, "Ruc", DbType.String, Ruc)
        DB.AddInParameter(DatabaseCommand, "Direccion", DbType.String, Direcion)
        DB.AddInParameter(DatabaseCommand, "Telefono", DbType.String, Telefono)
        DB.AddInParameter(DatabaseCommand, "Correo", DbType.String, Correo)

        Dim rpta As String
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                'Ejecuta el Procedimiento Almacenado
                rpta = If(DB.ExecuteNonQuery(DatabaseCommand) = 1, "ok", "El Registro No pudo ser insertado")
                Return rpta
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function InsertarEmpleado(ByVal Nombre As String, ByVal Apellidos As String, ByVal IdTipoDocumento As Int16, ByVal NumDocumento As String, ByVal Edad As Int16, ByVal sexo As String, ByVal Telefono As String, ByVal Direccion As String, ByVal Email As String, ByVal Estado As Int16) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarEmpleado"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "Nombre", DbType.String, Nombre)
        DB.AddInParameter(DatabaseCommand, "Apellidos", DbType.String, Apellidos)
        DB.AddInParameter(DatabaseCommand, "IdTipoDocumento", DbType.Int16, IdTipoDocumento)
        DB.AddInParameter(DatabaseCommand, "NumDocumento", DbType.String, NumDocumento)
        DB.AddInParameter(DatabaseCommand, "Edad", DbType.Int16, Edad)
        DB.AddInParameter(DatabaseCommand, "Sexo", DbType.String, sexo)
        DB.AddInParameter(DatabaseCommand, "Telefono", DbType.String, Telefono)
        DB.AddInParameter(DatabaseCommand, "Direccion", DbType.String, Direccion)
        DB.AddInParameter(DatabaseCommand, "Email", DbType.String, Email)
        DB.AddInParameter(DatabaseCommand, "Estado", DbType.Int16, Estado)

        Dim rpta As String
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                rpta = CType(DB.ExecuteScalar(DatabaseCommand), String)
                Return rpta
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function ActualizarEmpleado(ByVal Nombre As String, ByVal Apellidos As String, ByVal IdTipoDocumento As Int16, ByVal NumDocumento As String, ByVal Edad As Int16, ByVal sexo As String, ByVal Telefono As String, ByVal Direccion As String, ByVal Email As String, ByVal Estado As Int16, IdEmpleado As Int32) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "ActualizarEmpleado"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "Nombre", DbType.String, Nombre)
        DB.AddInParameter(DatabaseCommand, "Apellidos", DbType.String, Apellidos)
        DB.AddInParameter(DatabaseCommand, "IdTipoDocumento", DbType.Int16, IdTipoDocumento)
        DB.AddInParameter(DatabaseCommand, "NumDocumento", DbType.String, NumDocumento)
        DB.AddInParameter(DatabaseCommand, "Edad", DbType.Int16, Edad)
        DB.AddInParameter(DatabaseCommand, "Sexo", DbType.String, sexo)
        DB.AddInParameter(DatabaseCommand, "Telefono", DbType.String, Telefono)
        DB.AddInParameter(DatabaseCommand, "Direccion", DbType.String, Direccion)
        DB.AddInParameter(DatabaseCommand, "Email", DbType.String, Email)
        DB.AddInParameter(DatabaseCommand, "Estado", DbType.Int16, Estado)
        DB.AddInParameter(DatabaseCommand, "IdEmpleado", DbType.Int16, IdEmpleado)
        Dim rpta As String
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                rpta = If(DB.ExecuteNonQuery(DatabaseCommand) = 1, "ok", "El Registro No pudo ser insertado")
                Return rpta
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function InsertarDetalleProyecto(ByVal IdProyecto As Int16, Cantidad As Int16, Descripcion As String, ValorUnitario As Decimal, ValorTotal As Decimal, Observacion As String) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarDetalleProyecto"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdProyecto", DbType.Int16, IdProyecto)
        DB.AddInParameter(DatabaseCommand, "Cantidad", DbType.Int16, Cantidad)
        DB.AddInParameter(DatabaseCommand, "Descripcion", DbType.String, Descripcion)
        DB.AddInParameter(DatabaseCommand, "ValorUnitario", DbType.Decimal, ValorUnitario)
        DB.AddInParameter(DatabaseCommand, "ValorTotal", DbType.Decimal, ValorTotal)
        DB.AddInParameter(DatabaseCommand, "Observacion", DbType.String, Observacion)

        Dim rpta As String
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                rpta = If(DB.ExecuteNonQuery(DatabaseCommand) = 1, "ok", "El Registro No pudo ser insertado")
                Return rpta
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function ActualizarDetalleProyecto(ByVal IdProyecto As Int16, Cantidad As Int16, Descripcion As String, ValorUnitario As Decimal, ValorTotal As Decimal, Observacion As String, IdDetalleProyecto As Int32) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "ActualizarDetalleProyecto"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdProyecto", DbType.Int16, IdProyecto)
        DB.AddInParameter(DatabaseCommand, "Cantidad", DbType.Int16, Cantidad)
        DB.AddInParameter(DatabaseCommand, "Descripcion", DbType.String, Descripcion)
        DB.AddInParameter(DatabaseCommand, "ValorUnitario", DbType.Decimal, ValorUnitario)
        DB.AddInParameter(DatabaseCommand, "ValorTotal", DbType.Decimal, ValorTotal)
        DB.AddInParameter(DatabaseCommand, "Observacion", DbType.String, Observacion)
        DB.AddInParameter(DatabaseCommand, "IdDetalleProyecto", DbType.String, IdDetalleProyecto)

        Dim rpta As String
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                rpta = If(DB.ExecuteNonQuery(DatabaseCommand) = 1, "ok", "El Registro No pudo ser Actualizado")
                Return rpta
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function


    Public Function InsertarmanoDeObra(ByVal IdProyecto As Int16, Descripcion As String, CantidadPersonas As Int16, Tiempo As String) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarmanoDeObra"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdProyecto", DbType.Int16, IdProyecto)
        DB.AddInParameter(DatabaseCommand, "Descripcion", DbType.String, Descripcion)
        DB.AddInParameter(DatabaseCommand, "CantidadPersonas", DbType.Int16, CantidadPersonas)
        DB.AddInParameter(DatabaseCommand, "Tiempo", DbType.String, Tiempo)


        Dim rpta As String
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                rpta = If(DB.ExecuteNonQuery(DatabaseCommand) = 1, "ok", "El Registro No pudo ser insertado")
                Return rpta
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function ActualizarManoDeObra(ByVal IdProyecto As Int16, Descripcion As String, CantidadPersonas As Int16, Tiempo As String, IdManoObra As Int32) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "ActualizarManoDeObra"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdProyecto", DbType.Int16, IdProyecto)
        DB.AddInParameter(DatabaseCommand, "Descripcion", DbType.String, Descripcion)
        DB.AddInParameter(DatabaseCommand, "CantidadPersonas", DbType.Int16, CantidadPersonas)
        DB.AddInParameter(DatabaseCommand, "Tiempo", DbType.String, Tiempo)
        DB.AddInParameter(DatabaseCommand, "IdManoObra", DbType.Int32, IdManoObra)

        Dim rpta As String
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                rpta = If(DB.ExecuteNonQuery(DatabaseCommand) = 1, "ok", "El Registro No pudo ser actualizado")
                Return rpta
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function ActualizarProyecto(ByVal Nombre As String, Descripcion As String, Estado As Int16, IdEmpleado As Int16, IdCliente As Int16, Area As String, IdProyecto As Integer) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "ActualizarProyecto"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)


        DB.AddInParameter(DatabaseCommand, "IdProyecto", DbType.Int32, IdProyecto)
        DB.AddInParameter(DatabaseCommand, "Nombre", DbType.String, Nombre)
        DB.AddInParameter(DatabaseCommand, "Descripcion", DbType.String, Descripcion)
        DB.AddInParameter(DatabaseCommand, "Estado", DbType.Int16, Estado)
        DB.AddInParameter(DatabaseCommand, "IdEmpleado", DbType.Int16, IdEmpleado)
        DB.AddInParameter(DatabaseCommand, "IdCliente", DbType.Int16, IdCliente)
        DB.AddInParameter(DatabaseCommand, "Area", DbType.String, Area)

        Dim rpta As String
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                rpta = If(DB.ExecuteNonQuery(DatabaseCommand) = 1, "ok", "El Registro No pudo ser actualizado")
                Return rpta
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function InsertarProyecto(ByVal Nombre As String, Descripcion As String, Estado As Int16, IdEmpleado As Int16, IdCliente As Int16, Area As String) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarProyecto"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "Nombre", DbType.String, Nombre)
        DB.AddInParameter(DatabaseCommand, "Descripcion", DbType.String, Descripcion)
        DB.AddInParameter(DatabaseCommand, "Estado", DbType.Int16, Estado)
        DB.AddInParameter(DatabaseCommand, "IdEmpleado", DbType.Int16, IdEmpleado)
        DB.AddInParameter(DatabaseCommand, "IdCliente", DbType.Int16, IdCliente)
        DB.AddInParameter(DatabaseCommand, "Area", DbType.String, Area)

        Dim rpta As String
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                rpta = If(DB.ExecuteNonQuery(DatabaseCommand) = 1, "ok", "El Registro No pudo ser insertado")
                Return rpta
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function InsertarUsuario(ByVal IdEmpleado As Int32, ByVal Usuario As String, Clave As String, IdTipoUsuario As Int16) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarUsuario"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdEmpleado", DbType.Int32, IdEmpleado)
        DB.AddInParameter(DatabaseCommand, "Usuario", DbType.String, Usuario)
        DB.AddInParameter(DatabaseCommand, "Clave", DbType.String, Clave)
        DB.AddInParameter(DatabaseCommand, "IdTipoUsuario", DbType.Int16, IdTipoUsuario)

        Dim rpta As String
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                rpta = If(DB.ExecuteNonQuery(DatabaseCommand) = 1, "ok", "El Registro No pudo ser insertado")
                Return rpta
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function ActualizarUsuario(ByVal IdEmpleado As Int32, ByVal Usuario As String, Clave As String, IdTipoUsuario As Int16, IdUsuario As Int32) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "ActualizarUsuario"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdEmpleado", DbType.Int32, IdEmpleado)
        DB.AddInParameter(DatabaseCommand, "Usuario", DbType.String, Usuario)
        DB.AddInParameter(DatabaseCommand, "Clave", DbType.String, Clave)
        DB.AddInParameter(DatabaseCommand, "IdTipoUsuario", DbType.Int16, IdTipoUsuario)
        DB.AddInParameter(DatabaseCommand, "IdUsuario", DbType.Int32, IdUsuario)

        Dim rpta As String
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                rpta = If(DB.ExecuteNonQuery(DatabaseCommand) = 1, "ok", "El Registro No pudo ser insertado")
                Return rpta
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function ListarEmpleados() As List(Of Empleado)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarEmpleados"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        Dim Lista As New List(Of Empleado)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Dim reader As IDataReader = DB.ExecuteReader(DatabaseCommand)

                'CREAR OBJETOS DE TIPO EMPLEADO
                While reader.Read
                    Dim oempleado As New Empleado
                    oempleado.IdEmpleado = Convert.ToInt32(reader("IdEmpleado").ToString())
                    oempleado.Nombre = reader("Nombre").ToString()
                    oempleado.Apellidos = reader("Apellidos").ToString()
                    oempleado.NumeroDocumento = reader("NumeroDocumento").ToString()
                    oempleado.Sexo = reader("Sexo").ToString()
                    oempleado.Telefono = reader("Telefono").ToString()
                    oempleado.Direccion = reader("Direccion").ToString()
                    oempleado.Email = reader("Email").ToString()
                    Dim estado As String = reader("Estado").ToString()
                    If estado.Contains("Activo") Then
                        oempleado.Estado = 1
                    Else
                        oempleado.Estado = 2
                    End If

                    'A�ADIR A LA LISTA DE OBJETO
                    Lista.Add(oempleado)
                End While
                Return Lista
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarImagenes(ByVal Idproyecto As Int32) As DataTable
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarImagenesProyectos"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "Idproyecto", DbType.Int32, Idproyecto)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteDataSet(DatabaseCommand).Tables(0)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function


    Public Function InsertarImagenProyecto(ByVal Idproyecto As Int32, ByVal Imagen As Byte(), ByVal Tituloimagen As String, ByVal NumeroImagen As Int32) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarImagenProyecto"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "Idproyecto", DbType.Int32, Idproyecto)
        DB.AddInParameter(DatabaseCommand, "Imagen", DbType.Binary, Imagen)
        DB.AddInParameter(DatabaseCommand, "Tituloimagen", DbType.String, Tituloimagen)
        DB.AddInParameter(DatabaseCommand, "NumeroImagen", DbType.Int32, NumeroImagen)

        Dim rpta As String
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                rpta = If(DB.ExecuteNonQuery(DatabaseCommand) = 1, "ok", "El Registro No pudo ser insertado")
                Return rpta
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarEmpresa() As IDataReader
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarEmpresa"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()
            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteReader(DatabaseCommand)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

#End Region
End Class











Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Data
Imports CapaEntidades
Imports System


<Serializable>
Public Class DataAccess

#Region "LITOGRAFIA"

    Public Sub EliminarCotizacion(idcotizacion As Integer)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "EliminarCotizacion"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdCotizacion", DbType.Int32, idcotizacion)

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

    Public Function RecuperarCotizacionIdClientePorFiltro(filtro As Integer, text As String, idcliente As Integer) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "RecuperarCotizacionIdClientePorFiltro"
        Dim dbCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)

        db.AddInParameter(dbCommand, "Filtro", DbType.Int32, filtro)
        db.AddInParameter(dbCommand, "Texto", DbType.String, text)
        db.AddInParameter(dbCommand, "IdCliente", DbType.String, idcliente)

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


    Public Function RecuperarCotizacionesPorFiltro(filtro As Integer, text As String) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "RecuperarCotizacionesPorFiltro"
        Dim dbCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)

        db.AddInParameter(dbCommand, "Filtro", DbType.Int32, filtro)
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

    Public Function InsertarCotizacion(IdCliente As Integer,
                                        IdProducto As Integer,
                                        IdPapel As Integer,
                                        IdCorte As Integer,
                                        Cantidad As Integer,
                                        CostoDiseno As Decimal,
                                        Cavidad As Integer,
                                        Montaje As String,
                                        Frente As Boolean,
                                        Respaldo As Boolean,
                                        ColoresFrente As Integer,
                                        ColoresRespaldo As Integer,
                                        MismaPlancha As Boolean,
                                        TotalAcabados As Decimal,
                                        SubtotalFactura As Decimal,
                                        ValorGanancia As Decimal,
                                        PorcentajeGanancia As Decimal,
                                        TotalFactura As Decimal) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "InsertarCotizacion"
        Dim dbCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)

        db.AddInParameter(dbCommand, "IdCliente", DbType.Int32, IdCliente)

        db.AddInParameter(dbCommand, "IdProducto", DbType.Int32, IdProducto)

        db.AddInParameter(dbCommand, "IdPapel", DbType.Int32, IdPapel)

        db.AddInParameter(dbCommand, "IdCorte", DbType.Int32, IdCorte)

        db.AddInParameter(dbCommand, "Cantidad", DbType.Int32, Cantidad)

        db.AddInParameter(dbCommand, "CostoDiseno", DbType.Decimal, CostoDiseno)

        db.AddInParameter(dbCommand, "Cavidad", DbType.Int32, Cavidad)

        db.AddInParameter(dbCommand, "Montaje", DbType.String, Montaje)

        db.AddInParameter(dbCommand, "Frente", DbType.Boolean, Frente)

        db.AddInParameter(dbCommand, "Respaldo", DbType.Boolean, Respaldo)

        db.AddInParameter(dbCommand, "ColoresFrente", DbType.Int32, ColoresFrente)

        db.AddInParameter(dbCommand, "ColoresRespaldo", DbType.Int32, ColoresRespaldo)

        db.AddInParameter(dbCommand, "MismaPlancha", DbType.Boolean, MismaPlancha)

        db.AddOutParameter(dbCommand, "IdCotizacion", DbType.Int32, Integer.MaxValue)

        db.AddInParameter(dbCommand, "TotalAcabados", DbType.Decimal, TotalAcabados)

        db.AddInParameter(dbCommand, "SubtotalFactura", DbType.Decimal, SubtotalFactura)

        db.AddInParameter(dbCommand, "ValorGanancia", DbType.Decimal, ValorGanancia)

        db.AddInParameter(dbCommand, "PorcentajeGanancia", DbType.Decimal, PorcentajeGanancia)

        db.AddInParameter(dbCommand, "TotalFactura", DbType.Decimal, TotalFactura)



        Using connection As DbConnection = db.CreateConnection()
            connection.Open()
            Try
                db.ExecuteNonQuery(dbCommand)

                Dim IdCotizacion As Integer = Convert.ToInt32(db.GetParameterValue(dbCommand, "IdCotizacion"))

                Return IdCotizacion

            Catch ex As Exception
                Throw ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Sub InsertarAcabadoCotizacion(Nombre As String,
                                        Precio As Decimal,
                                        ValorTroqueado As Nullable(Of Decimal),
                                        TipoTroquelado As String,
                                        FrenteAcabado As Nullable(Of Boolean),
                                        RespaldoAcabado As Nullable(Of Boolean),
                                        IdCotizacion As Integer,
                                        IdAcabado As Integer
                                        )
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "InsertarAcabadoCotizacion"
        Dim dbCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)

        db.AddInParameter(dbCommand, "Nombre", DbType.String, Nombre)

        db.AddInParameter(dbCommand, "Precio", DbType.Decimal, Precio)

        db.AddInParameter(dbCommand, "ValorTroqueado", DbType.Decimal, ValorTroqueado)

        db.AddInParameter(dbCommand, "TipoTroquelado", DbType.String, TipoTroquelado)

        db.AddInParameter(dbCommand, "FrenteAcabado", DbType.Boolean, FrenteAcabado)

        db.AddInParameter(dbCommand, "RespaldoAcabado", DbType.Boolean, RespaldoAcabado)

        db.AddInParameter(dbCommand, "IdCotizacion", DbType.Int32, IdCotizacion)

        db.AddInParameter(dbCommand, "IdAcabado", DbType.Int32, IdAcabado)

        db.AddOutParameter(dbCommand, "IdAcabadoCotizacion", DbType.Int32, Integer.MaxValue)


        Using connection As DbConnection = db.CreateConnection()
            connection.Open()
            Try
                db.ExecuteNonQuery(dbCommand)
            Catch ex As Exception
                Throw ex
            Finally
                connection.Close()
            End Try
        End Using

    End Sub

    Public Function RecuperarAcabado(idLitografia As Integer, codigo As String) As IDataReader
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "RecuperarAcabado"
        Dim dbCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)

        db.AddInParameter(dbCommand, "IdLitografia", DbType.Int32, idLitografia)

        db.AddInParameter(dbCommand, "Codigo", DbType.String, codigo)

        Using connection As DbConnection = db.CreateConnection()
            connection.Open()
            Try
                Return db.ExecuteReader(dbCommand)
            Catch ex As Exception
                Throw ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarAcabados(idLitografia As Integer) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "RecuperarAcabados"
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

    Public Function RecuperarCotizacionPorIdCliente(idCliente As Integer) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "RecuperarCotizacionPorIdcliente"
        Dim dbCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)

        db.AddInParameter(dbCommand, "IdCliente", DbType.Int32, idCliente)

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

    Public Function RecuperarProductos(ByVal Idlitografia As Int32) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "Recuperarproductos"
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

    Public Function RecuperarCorte(idLitografia As Integer) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "RecuperarCorte"
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

    Public Function RecuperarMontaje(idCorte As Integer) As String
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "RecuperarMontaje"
        Dim dbCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)

        If (idCorte < 1) Then Return String.Empty

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

    Public Function RecuperarPrecioPapel(idPapel As Integer) As Decimal
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim sqlCommand As String = "RecuperarPrecioPapel"
        Dim dbCommand As DbCommand = db.GetStoredProcCommand(sqlCommand)

        db.AddInParameter(dbCommand, "IdPapel", DbType.Int32, idPapel)

        Using connection As DbConnection = db.CreateConnection()
            connection.Open()
            Try
                Return Convert.ToDecimal(db.ExecuteScalar(dbCommand))
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
        DB.AddInParameter(DatabaseCommand, "Nombre", DbType.String, nombre.ToUpper())
        DB.AddInParameter(DatabaseCommand, "Telefono", DbType.String, telefono)
        DB.AddInParameter(DatabaseCommand, "Direccion", DbType.String, direccion.ToUpper())
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

        DB.AddInParameter(DatabaseCommand, "Nombre", DbType.String, nombre.ToUpper())
        DB.AddInParameter(DatabaseCommand, "Telefono", DbType.String, telefono)
        DB.AddInParameter(DatabaseCommand, "Direccion", DbType.String, direccion.ToUpper())
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
#End Region


End Class











using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exanim.root.Migrations
{
    /// <inheritdoc />
    public partial class Global : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "CFParametro",
                columns: table => new
                {
                    ParametroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Clave = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CFParametro", x => x.ParametroId);
                });

            migrationBuilder.CreateTable(
                name: "CFPerfil",
                columns: table => new
                {
                    PerfilId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Grupo = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CFPerfil", x => x.PerfilId);
                });

            migrationBuilder.CreateTable(
                name: "VECompania",
                columns: table => new
                {
                    CompaniaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFC = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: false),
                    RazonSocial = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VECompania", x => x.CompaniaId);
                });

            migrationBuilder.CreateTable(
                name: "VEUnidad",
                columns: table => new
                {
                    UnidadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Placa = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Modelo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Anio = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    Color = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Registrado = table.Column<DateTime>(type: "datetime", nullable: false),
                    MarcaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEUnidad", x => x.UnidadId);
                    table.ForeignKey(
                        name: "FK_VEUnidad_Brand_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Brand",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CFUsuario",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Usuario = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    Correo = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    PerfilId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CFUsuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_CFUsuario_CFPerfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "CFPerfil",
                        principalColumn: "PerfilId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CFAgencia",
                columns: table => new
                {
                    AgenciaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFC = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: false),
                    RazonSocial = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    PlanEnum = table.Column<byte>(type: "tinyint", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CFAgencia", x => x.AgenciaId);
                    table.ForeignKey(
                        name: "FK_CFAgencia_CFUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "CFUsuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VEGestor",
                columns: table => new
                {
                    GestorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompaniaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEGestor", x => x.GestorId);
                    table.ForeignKey(
                        name: "FK_VEGestor_CFUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "CFUsuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VEGestor_VECompania_CompaniaId",
                        column: x => x.CompaniaId,
                        principalTable: "VECompania",
                        principalColumn: "CompaniaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CFConfigura",
                columns: table => new
                {
                    AgenciaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParametroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    Cadena = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CFConfigura", x => new { x.AgenciaId, x.ParametroId });
                    table.ForeignKey(
                        name: "FK_CFConfigura_CFAgencia_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "CFAgencia",
                        principalColumn: "AgenciaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CFConfigura_CFParametro_ParametroId",
                        column: x => x.ParametroId,
                        principalTable: "CFParametro",
                        principalColumn: "ParametroId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CFOperador",
                columns: table => new
                {
                    OperadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgenciaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CFOperador", x => x.OperadorId);
                    table.ForeignKey(
                        name: "FK_CFOperador_CFAgencia_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "CFAgencia",
                        principalColumn: "AgenciaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CFOperador_CFUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "CFUsuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CFTaller",
                columns: table => new
                {
                    TallerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    AgenciaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Lugar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CFTaller", x => x.TallerId);
                    table.ForeignKey(
                        name: "FK_CFTaller_CFAgencia_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "CFAgencia",
                        principalColumn: "AgenciaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CFTaller_CFUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "CFUsuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OPClase",
                columns: table => new
                {
                    ClaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    AgenciaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPClase", x => x.ClaseId);
                    table.ForeignKey(
                        name: "FK_OPClase_CFAgencia_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "CFAgencia",
                        principalColumn: "AgenciaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OPEstatus",
                columns: table => new
                {
                    EstatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Fase = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    AgenciaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPEstatus", x => x.EstatusId);
                    table.ForeignKey(
                        name: "FK_OPEstatus_CFAgencia_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "CFAgencia",
                        principalColumn: "AgenciaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VECotizacion",
                columns: table => new
                {
                    CotizacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Clave = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    Vigencia = table.Column<DateTime>(type: "datetime", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Aceptada = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgenciaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrdenId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VECotizacion", x => x.CotizacionId);
                    table.ForeignKey(
                        name: "FK_VECotizacion_CFAgencia_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "CFAgencia",
                        principalColumn: "AgenciaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VECotizacion_CFUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "CFUsuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OPPieza",
                columns: table => new
                {
                    PiezaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgenciaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPPieza", x => x.PiezaId);
                    table.ForeignKey(
                        name: "FK_OPPieza_CFAgencia_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "CFAgencia",
                        principalColumn: "AgenciaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPPieza_CFUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "CFUsuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPPieza_OPClase_ClaseId",
                        column: x => x.ClaseId,
                        principalTable: "OPClase",
                        principalColumn: "ClaseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OPOrden",
                columns: table => new
                {
                    OrdenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Problema = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    Condicion = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    Correo = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: true),
                    FechaEntrega = table.Column<DateTime>(type: "datetime", nullable: true),
                    UnidadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GestorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TallerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPOrden", x => x.OrdenId);
                    table.ForeignKey(
                        name: "FK_OPOrden_CFTaller_TallerId",
                        column: x => x.TallerId,
                        principalTable: "CFTaller",
                        principalColumn: "TallerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPOrden_CFUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "CFUsuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPOrden_OPEstatus_EstatusId",
                        column: x => x.EstatusId,
                        principalTable: "OPEstatus",
                        principalColumn: "EstatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPOrden_VEGestor_GestorId",
                        column: x => x.GestorId,
                        principalTable: "VEGestor",
                        principalColumn: "GestorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPOrden_VEUnidad_UnidadId",
                        column: x => x.UnidadId,
                        principalTable: "VEUnidad",
                        principalColumn: "UnidadId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OPPaso",
                columns: table => new
                {
                    PasoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<byte>(type: "tinyint", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    PrevioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvanzaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPPaso", x => x.PasoId);
                    table.ForeignKey(
                        name: "FK_OPPaso_OPEstatus_AvanzaId",
                        column: x => x.AvanzaId,
                        principalTable: "OPEstatus",
                        principalColumn: "EstatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPPaso_OPEstatus_PrevioId",
                        column: x => x.PrevioId,
                        principalTable: "OPEstatus",
                        principalColumn: "EstatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VELinea",
                columns: table => new
                {
                    LineaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Clave = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Unidad = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Concepto = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    Cantidad = table.Column<float>(type: "real", nullable: false),
                    Precio = table.Column<float>(type: "real", nullable: false),
                    Importe = table.Column<float>(type: "real", nullable: false),
                    CotizacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VELinea", x => x.LineaId);
                    table.ForeignKey(
                        name: "FK_VELinea_VECotizacion_CotizacionId",
                        column: x => x.CotizacionId,
                        principalTable: "VECotizacion",
                        principalColumn: "CotizacionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OPAvance",
                columns: table => new
                {
                    AvanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Anotacion = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    Comentario = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    OrdenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPAvance", x => x.AvanceId);
                    table.ForeignKey(
                        name: "FK_OPAvance_CFUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "CFUsuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPAvance_OPEstatus_EstatusId",
                        column: x => x.EstatusId,
                        principalTable: "OPEstatus",
                        principalColumn: "EstatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPAvance_OPOrden_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "OPOrden",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OPInstalacion",
                columns: table => new
                {
                    InstalacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Marca = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    Cantidad = table.Column<float>(type: "real", nullable: false),
                    Serie = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Comentario = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    OrdenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PiezaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPInstalacion", x => x.InstalacionId);
                    table.ForeignKey(
                        name: "FK_OPInstalacion_OPOrden_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "OPOrden",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPInstalacion_OPPieza_PiezaId",
                        column: x => x.PiezaId,
                        principalTable: "OPPieza",
                        principalColumn: "PiezaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OPRemocion",
                columns: table => new
                {
                    RemocionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Marca = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Cantidad = table.Column<float>(type: "real", nullable: false),
                    Serie = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Comentario = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    OrdenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PiezaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPRemocion", x => x.RemocionId);
                    table.ForeignKey(
                        name: "FK_OPRemocion_OPOrden_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "OPOrden",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPRemocion_OPPieza_PiezaId",
                        column: x => x.PiezaId,
                        principalTable: "OPPieza",
                        principalColumn: "PiezaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OPAccion",
                columns: table => new
                {
                    AccionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EsPrevio = table.Column<bool>(type: "bit", nullable: false),
                    Autoriza = table.Column<bool>(type: "bit", nullable: false),
                    Notifica = table.Column<bool>(type: "bit", nullable: false),
                    PasoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerfilId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPAccion", x => x.AccionId);
                    table.ForeignKey(
                        name: "FK_OPAccion_OPPaso_PasoId",
                        column: x => x.PasoId,
                        principalTable: "OPPaso",
                        principalColumn: "PasoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OPAutoriza",
                columns: table => new
                {
                    AutorizaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Autorizado = table.Column<bool>(type: "bit", nullable: false),
                    Comentario = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    AvanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPAutoriza", x => x.AutorizaId);
                    table.ForeignKey(
                        name: "FK_OPAutoriza_OPAccion_AccionId",
                        column: x => x.AccionId,
                        principalTable: "OPAccion",
                        principalColumn: "AccionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPAutoriza_OPAvance_AccionId",
                        column: x => x.AccionId,
                        principalTable: "OPAvance",
                        principalColumn: "AvanceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CFAgencia_UsuarioId",
                table: "CFAgencia",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CFConfigura_ParametroId",
                table: "CFConfigura",
                column: "ParametroId");

            migrationBuilder.CreateIndex(
                name: "IX_CFOperador_AgenciaId",
                table: "CFOperador",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_CFOperador_UsuarioId",
                table: "CFOperador",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CFTaller_AgenciaId",
                table: "CFTaller",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_CFTaller_UsuarioId",
                table: "CFTaller",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CFUsuario_PerfilId",
                table: "CFUsuario",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_OPAccion_PasoId",
                table: "OPAccion",
                column: "PasoId");

            migrationBuilder.CreateIndex(
                name: "IX_OPAutoriza_AccionId",
                table: "OPAutoriza",
                column: "AccionId");

            migrationBuilder.CreateIndex(
                name: "IX_OPAvance_EstatusId",
                table: "OPAvance",
                column: "EstatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OPAvance_OrdenId",
                table: "OPAvance",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_OPAvance_UsuarioId",
                table: "OPAvance",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_OPClase_AgenciaId",
                table: "OPClase",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_OPEstatus_AgenciaId",
                table: "OPEstatus",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_OPInstalacion_OrdenId",
                table: "OPInstalacion",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_OPInstalacion_PiezaId",
                table: "OPInstalacion",
                column: "PiezaId");

            migrationBuilder.CreateIndex(
                name: "IX_OPOrden_EstatusId",
                table: "OPOrden",
                column: "EstatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OPOrden_GestorId",
                table: "OPOrden",
                column: "GestorId");

            migrationBuilder.CreateIndex(
                name: "IX_OPOrden_TallerId",
                table: "OPOrden",
                column: "TallerId");

            migrationBuilder.CreateIndex(
                name: "IX_OPOrden_UnidadId",
                table: "OPOrden",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_OPOrden_UsuarioId",
                table: "OPOrden",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_OPPaso_AvanzaId",
                table: "OPPaso",
                column: "AvanzaId");

            migrationBuilder.CreateIndex(
                name: "IX_OPPaso_PrevioId",
                table: "OPPaso",
                column: "PrevioId");

            migrationBuilder.CreateIndex(
                name: "IX_OPPieza_AgenciaId",
                table: "OPPieza",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_OPPieza_ClaseId",
                table: "OPPieza",
                column: "ClaseId");

            migrationBuilder.CreateIndex(
                name: "IX_OPPieza_UsuarioId",
                table: "OPPieza",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_OPRemocion_OrdenId",
                table: "OPRemocion",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_OPRemocion_PiezaId",
                table: "OPRemocion",
                column: "PiezaId");

            migrationBuilder.CreateIndex(
                name: "IX_VECotizacion_AgenciaId",
                table: "VECotizacion",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_VECotizacion_UsuarioId",
                table: "VECotizacion",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_VEGestor_CompaniaId",
                table: "VEGestor",
                column: "CompaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_VEGestor_UsuarioId",
                table: "VEGestor",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_VELinea_CotizacionId",
                table: "VELinea",
                column: "CotizacionId");

            migrationBuilder.CreateIndex(
                name: "IX_VEUnidad_MarcaId",
                table: "VEUnidad",
                column: "MarcaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CFConfigura");

            migrationBuilder.DropTable(
                name: "CFOperador");

            migrationBuilder.DropTable(
                name: "OPAutoriza");

            migrationBuilder.DropTable(
                name: "OPInstalacion");

            migrationBuilder.DropTable(
                name: "OPRemocion");

            migrationBuilder.DropTable(
                name: "VELinea");

            migrationBuilder.DropTable(
                name: "CFParametro");

            migrationBuilder.DropTable(
                name: "OPAccion");

            migrationBuilder.DropTable(
                name: "OPAvance");

            migrationBuilder.DropTable(
                name: "OPPieza");

            migrationBuilder.DropTable(
                name: "VECotizacion");

            migrationBuilder.DropTable(
                name: "OPPaso");

            migrationBuilder.DropTable(
                name: "OPOrden");

            migrationBuilder.DropTable(
                name: "OPClase");

            migrationBuilder.DropTable(
                name: "CFTaller");

            migrationBuilder.DropTable(
                name: "OPEstatus");

            migrationBuilder.DropTable(
                name: "VEGestor");

            migrationBuilder.DropTable(
                name: "VEUnidad");

            migrationBuilder.DropTable(
                name: "CFAgencia");

            migrationBuilder.DropTable(
                name: "VECompania");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "CFUsuario");

            migrationBuilder.DropTable(
                name: "CFPerfil");
        }
    }
}

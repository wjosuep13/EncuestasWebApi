

CREATE DATABASE Encuestas;

 use Encuestas;


CREATE TABLE EncuestaTable (
    id_encuesta int primary key identity,
	 nombre_encuesta varchar(255) not null,
    descripcion_encuesta varchar(255) not null,
	link varchar(300) 
);

CREATE TABLE RespuestasEncuesta (
	id_respuesta int primary key identity,
    fecha datetime default getdate(),
	respuestas text not null,
	id_encuesta int not null,
	CONSTRAINT FK_Respuesta_Encuesta FOREIGN KEY (id_encuesta)
    REFERENCES EncuestaTable(id_encuesta)
);


CREATE TABLE TipoCampo (
    id_tipo_campo int primary key identity,
	descripcion_tipo varchar(10) not null,
	tipo_html varchar(10) not null,

);

CREATE TABLE Campo (
	 id_campo int primary key identity,
    nombre_campo varchar(150) not null,
    titulo_campo varchar(150) not null,
	es_requerido BIT not null,
    id_tipo_campo int not null,
	id_encuesta int not null, 
	CONSTRAINT FK_Encuesta_Campo FOREIGN KEY (id_encuesta)
    REFERENCES EncuestaTable(id_encuesta) ON DELETE CASCADE,
	CONSTRAINT FK_TipoCampo FOREIGN KEY (id_tipo_campo)
    REFERENCES TipoCampo(id_tipo_campo)
);



GO
CREATE TRIGGER GenerateLink on EncuestaTable
FOR INSERT 
AS DECLARE @id_encuesta INT;
SET NOCOUNT ON;

SELECT @id_encuesta = ins.id_encuesta FROM INSERTED ins;

update EncuestaTable set link='https://localhost:5001/api/Encuesta?id='+CONVERT(varchar(10),@id_encuesta) where id_encuesta=@id_encuesta;
GO

insert into TipoCampo values('Texto','text');

insert into TipoCampo values('Número','number');

insert into TipoCampo values('Fecha','date');








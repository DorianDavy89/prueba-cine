use prueba_cine;

-- Tabla pelicula
CREATE TABLE pelicula (
    id_pelicula INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    duracion INT NOT NULL
);

-- Tabla sala_cine
CREATE TABLE sala_cine (
    id_sala_cine INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    estado VARCHAR(50) NOT NULL 
);

-- Tabla pelicula_salacine
CREATE TABLE pelicula_salacine (
    id_pelicula_sala INT IDENTITY(1,1) PRIMARY KEY,
    fecha_publicacion DATE NOT NULL,
    fecha_fin DATE NOT NULL,
    id_pelicula INT NOT NULL,
    id_sala_cine INT NOT NULL,
    FOREIGN KEY (id_pelicula) REFERENCES pelicula(id_pelicula),
    FOREIGN KEY (id_sala_cine) REFERENCES sala_cine(id_sala_cine)
);

SELECT * FROM [dbo].[pelicula];
SELECT * FROM [dbo].[sala_cine];
SELECT * FROM [dbo].[pelicula_salacine];

INSERT INTO [dbo].[sala_cine] VALUES ('Sala HD 1', 'Disponible'), ('Sala HD 2', 'Disponible'), ('Sala 2k 1', 'Disponible'), 
('Sala VIP', 'Disponible')

INSERT INTO [dbo].[pelicula_salacine] VALUES ('2025-10-06', '2025-11-06', 1, 3), ('2025-09-06', '2025-10-06', 3, 4),
('2025-09-15', '2025-11-15', 2, 2),  ('2025-10-01', '2025-12-06', 3, 1);



GO
CREATE PROCEDURE sp_BuscarPeliculaPorNombre
    @nombre VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    -- validacion de no vacios
    IF @nombre IS NULL OR LTRIM(RTRIM(@nombre)) = ''
    BEGIN
        RAISERROR('El nombre de la película es requerido', 16, 1);
        RETURN;
    END
    
    SELECT 
        id_pelicula,
        nombre,
        duracion
    FROM pelicula
    WHERE nombre LIKE '%' + @nombre + '%'
    ORDER BY nombre;
    
    IF @@ROWCOUNT = 0
    BEGIN
        PRINT 'No se encontraron películas con ese nombre';
    END
END;
GO

EXEC sp_BuscarPeliculaPorNombre @nombre = '';
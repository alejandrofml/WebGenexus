CREATE TABLE [Venta] ([VentaId] smallint NOT NULL IDENTITY(1,1), [VentaHoraFecha] datetime NOT NULL , [SectorId] smallint NOT NULL , [EventoId] smallint NOT NULL , PRIMARY KEY([VentaId]));
CREATE NONCLUSTERED INDEX [IVENTA1] ON [Venta] ([EventoId] ,[SectorId] );

CREATE TABLE [TipoEspectaculo] ([TipoEspectaculoId] smallint NOT NULL IDENTITY(1,1), [TipoEspectaculoNombre] nvarchar(100) NOT NULL , PRIMARY KEY([TipoEspectaculoId]));

CREATE TABLE [Pais] ([PaisId] smallint NOT NULL IDENTITY(1,1), [PaisNombre] nvarchar(100) NOT NULL , PRIMARY KEY([PaisId]));

CREATE TABLE [Sector] ([SectorId] smallint NOT NULL IDENTITY(1,1), [SectorNombre] nvarchar(100) NOT NULL , [SectorCapacidad] smallint NOT NULL , [SectorPrecio] smallint NOT NULL , [LugarId] smallint NOT NULL , PRIMARY KEY([SectorId]));
CREATE NONCLUSTERED INDEX [ISECTOR1] ON [Sector] ([LugarId] );

CREATE TABLE [Lugar] ([LugarId] smallint NOT NULL IDENTITY(1,1), [LugarNombre] nvarchar(100) NOT NULL , [LugarDireccion] nvarchar(1024) NOT NULL , [PaisId] smallint NOT NULL , PRIMARY KEY([LugarId]));
CREATE NONCLUSTERED INDEX [ILUGAR1] ON [Lugar] ([PaisId] );

CREATE TABLE [Invitacion] ([InvitacionId] smallint NOT NULL IDENTITY(1,1), [InvitacionNombre] nvarchar(100) NOT NULL , [InvitacionNominada] BIT NOT NULL , [EventoId] smallint NOT NULL , [SectorId] smallint NOT NULL , PRIMARY KEY([InvitacionId]));
CREATE NONCLUSTERED INDEX [IINVITACION1] ON [Invitacion] ([EventoId] ,[SectorId] );

CREATE TABLE [EventoSector] ([EventoId] smallint NOT NULL , [SectorId] smallint NOT NULL , PRIMARY KEY([EventoId], [SectorId]));
CREATE NONCLUSTERED INDEX [IEVENTOSECTOR1] ON [EventoSector] ([SectorId] );

CREATE TABLE [Evento] ([EventoId] smallint NOT NULL IDENTITY(1,1), [EventoHoraFecha] datetime NOT NULL , [EspectaculoId] smallint NOT NULL , [LugarId] smallint NOT NULL , PRIMARY KEY([EventoId]));
CREATE NONCLUSTERED INDEX [IEVENTO2] ON [Evento] ([EspectaculoId] );
CREATE NONCLUSTERED INDEX [IEVENTO1] ON [Evento] ([LugarId] );

CREATE TABLE [Espectaculo] ([EspectaculoId] smallint NOT NULL IDENTITY(1,1), [EspectaculoNombre] nvarchar(100) NOT NULL , [EspectaculoDescripcion] nvarchar(500) NOT NULL , [EspectaculoImagen] VARBINARY(MAX) NOT NULL , [EspectaculoImagen_GXI] varchar(2048) NULL , [TipoEspectaculoId] smallint NOT NULL , PRIMARY KEY([EspectaculoId]));
CREATE NONCLUSTERED INDEX [IESPECTACULO1] ON [Espectaculo] ([TipoEspectaculoId] );

ALTER TABLE [Espectaculo] ADD CONSTRAINT [IESPECTACULO1] FOREIGN KEY ([TipoEspectaculoId]) REFERENCES [TipoEspectaculo] ([TipoEspectaculoId]);

ALTER TABLE [Evento] ADD CONSTRAINT [IEVENTO2] FOREIGN KEY ([EspectaculoId]) REFERENCES [Espectaculo] ([EspectaculoId]);
ALTER TABLE [Evento] ADD CONSTRAINT [IEVENTO1] FOREIGN KEY ([LugarId]) REFERENCES [Lugar] ([LugarId]);

ALTER TABLE [EventoSector] ADD CONSTRAINT [IEVENTOSECTOR2] FOREIGN KEY ([EventoId]) REFERENCES [Evento] ([EventoId]);
ALTER TABLE [EventoSector] ADD CONSTRAINT [IEVENTOSECTOR1] FOREIGN KEY ([SectorId]) REFERENCES [Sector] ([SectorId]);

ALTER TABLE [Invitacion] ADD CONSTRAINT [IINVITACION1] FOREIGN KEY ([EventoId], [SectorId]) REFERENCES [EventoSector] ([EventoId], [SectorId]);

ALTER TABLE [Lugar] ADD CONSTRAINT [ILUGAR1] FOREIGN KEY ([PaisId]) REFERENCES [Pais] ([PaisId]);

ALTER TABLE [Sector] ADD CONSTRAINT [ISECTOR1] FOREIGN KEY ([LugarId]) REFERENCES [Lugar] ([LugarId]);

ALTER TABLE [Venta] ADD CONSTRAINT [IVENTA1] FOREIGN KEY ([EventoId], [SectorId]) REFERENCES [EventoSector] ([EventoId], [SectorId]);


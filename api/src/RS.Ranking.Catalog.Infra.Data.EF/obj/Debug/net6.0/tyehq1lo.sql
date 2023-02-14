DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM pg_namespace WHERE nspname = 'ranking') THEN
        CREATE SCHEMA ranking;
    END IF;
END $EF$;
CREATE TABLE IF NOT EXISTS ranking."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM pg_namespace WHERE nspname = 'ranking') THEN
        CREATE SCHEMA ranking;
    END IF;
END $EF$;

CREATE TABLE ranking."Categories" (
    "Id" uuid NOT NULL,
    "Name" character varying(255) NOT NULL,
    "Description" character varying(10000) NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedAt" date NOT NULL,
    CONSTRAINT "PK_Categories" PRIMARY KEY ("Id")
);

INSERT INTO ranking."Categories" ("Id", "CreatedAt", "Description", "IsActive", "Name")
VALUES ('22d4aa78-89f5-449e-9a7c-df6d3f8e9e31', DATE '2023-02-13', 'Descrição do eletrônico', TRUE, 'Eletrônicos');

CREATE INDEX "IX_Categories_CreatedAt" ON ranking."Categories" ("CreatedAt");

INSERT INTO ranking."__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230214104306_Inicio', '7.0.2');

COMMIT;


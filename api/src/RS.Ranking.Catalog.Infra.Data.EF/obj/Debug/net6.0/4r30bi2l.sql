CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Categories" (
    "Id" uuid NOT NULL,
    "Name" character varying(255) NOT NULL,
    "Description" character varying(10000) NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedAt" date NOT NULL,
    CONSTRAINT "PK_Categories" PRIMARY KEY ("Id")
);

INSERT INTO "Categories" ("Id", "CreatedAt", "Description", "IsActive", "Name")
VALUES ('e883005e-5bc8-4025-a5be-675ffdbabebe', DATE '2023-02-13', 'Descrição do eletrônico', TRUE, 'Eletrônicos');

CREATE INDEX "IX_Categories_CreatedAt" ON "Categories" ("CreatedAt");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230213201032_Inicio', '6.0.4');

COMMIT;


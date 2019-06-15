USE master;
GO

IF (EXISTS(select * from sys.databases where name='FamilyRecipeBook'))
	DROP DATABASE FamilyRecipeBook;
GO

CREATE DATABASE FamilyRecipeBook;
GO

USE FamilyRecipeBook;
GO


BEGIN TRANSACTION;

CREATE TABLE family(
	id INT IDENTITY(1,1),
	name NVARCHAR(25) NOT NULL,

	CONSTRAINT PK_family_id PRIMARY KEY (id)
);

CREATE TABLE users(
	id INT IDENTITY(1,1),
	display_name NVARCHAR(25) NOT NULL,
	email NVARCHAR(MAX) NOT NULL,
	password NVARCHAR(MAX) NOT NULL,
	salt NVARCHAR(MAX) NOT NULL,
	role NVARCHAR(MAX) NOT NULL,
	family_id INT,
	family_role NVARCHAR(15),

	CONSTRAINT PK_user_id PRIMARY KEY (id),
	CONSTRAINT FK_user_family FOREIGN KEY (family_id) REFERENCES family(id)
);

CREATE TABLE invite(
	id INT IDENTITY(1,1),
	invite_family_id INT NOT NULL,
	invite_user_id INT NOT NULL,
	invited_by_user_id INT NOT NULL,

	CONSTRAINT PK_invite PRIMARY KEY (id),
	CONSTRAINT FK_invite_family FOREIGN KEY (invite_family_id) REFERENCES family(id),
	CONSTRAINT FK_invite_user FOREIGN KEY (invite_user_id) REFERENCES users(id),
	CONSTRAINT FK_invite_user FOREIGN KEY (invited_by_user_id) REFERENCES users(id)
);

CREATE TABLE website_requests(
	id INT IDENTITY(1,1),
	base_url VARCHAR(MAX) NOT NULL,
	full_url VARCHAR(MAX) NOT NULL,
	user_id int NOT NULL,

	CONSTRAINT PK_request_id PRIMARY KEY (id),
	CONSTRAINT FK_wr_user FOREIGN KEY (user_id) REFERENCES users(id)
);

CREATE TABLE recipe(
	id INT IDENTITY(1,1),
	name VARCHAR(200) NOT NULL,
	description TEXT NOT NULL,
	prep_minutes int NOT NULL,
	cook_minutes int NOT NULL,
	source VARCHAR(500) NOT NULL,
	date_added DATE NOT NULL,
	user_id INT NOT NULL,
	family_id INT,
	public_key NVARCHAR(6),

	CONSTRAINT PK_recipe_id PRIMARY KEY (id),
	CONSTRAINT FK_recipe_user FOREIGN KEY (user_id) REFERENCES users(id),
	CONSTRAINT FK_recipe_family FOREIGN KEY (family_id) REFERENCES family(id)
);

CREATE TABLE ingredient(
	id INT IDENTITY(1,1),
	ingredient VARCHAR(MAX) NOT NULL,
	recipe_id int NOT NULL,

	CONSTRAINT PK_ingredient_id PRIMARY KEY (id),
	CONSTRAINT FK_recipe_ingredient FOREIGN KEY (recipe_id) REFERENCES recipe(id)
);

CREATE TABLE images(
	id INT IDENTITY(1,1),
	recipe_id INT NOT NULL,
	filename TEXT NOT NULL,

	CONSTRAINT PK_image_id PRIMARY KEY (id),
	CONSTRAINT FK_recipe_image FOREIGN KEY (recipe_id) REFERENCES recipe(id)
);

CREATE TABLE steps(
	recipe_id INT NOT NULL,
	step_number INT NOT NULL,
	step_text VARCHAR(MAX) NOT NULL,

	CONSTRAINT PK_step PRIMARY KEY (recipe_id, step_number),
	CONSTRAINT FK_recipe_step FOREIGN KEY (recipe_id) REFERENCES recipe(id)
);

COMMIT TRANSACTION;
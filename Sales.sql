USE Sales
GO

CREATE TABLE City (
	id int IDENTITY(1,1) NOT NULL,
	name nvarchar(30) NOT NULL
)
GO

ALTER TABLE City
ADD CONSTRAINT PK_Town_ID PRIMARY KEY CLUSTERED (id)
GO

CREATE TABLE Contact (
	id int IDENTITY(1,1) NOT NULL,
	client nvarchar(30) NOT NULL,
	sales_man nvarchar(30) NOT NULL
)
GO

ALTER TABLE Contact
ADD CONSTRAINT PK_Contact_ID PRIMARY KEY CLUSTERED (id)
GO

CREATE TABLE Agent (
	id int IDENTITY(1,1) NOT NULL,
	client nvarchar(30) NOT NULL,
	city_id int NOT NULL
)
GO

ALTER TABLE Agent
ADD CONSTRAINT PK_Agent_ID PRIMARY KEY CLUSTERED (id)
GO

CREATE TABLE Sale (
	id int IDENTITY(1,1) NOT NULL,
	name nvarchar(30) NOT NULL,
	agent_id int NULL,
	contact_id int NULL
)
GO

ALTER TABLE Sale
ADD CONSTRAINT PK_Sale_ID PRIMARY KEY CLUSTERED (id)
GO

ALTER TABLE Agent 
WITH CHECK ADD CONSTRAINT FK_Agent_City FOREIGN KEY (city_id)
REFERENCES City (id)
ON DELETE CASCADE
GO

ALTER TABLE Sale
WITH CHECK ADD CONSTRAINT FK_Sale_Agent FOREIGN KEY (agent_id)
REFERENCES Agent (id)
ON DELETE CASCADE
GO

ALTER TABLE Sale
WITH CHECK ADD CONSTRAINT FK_Sale_Contact FOREIGN KEY (contact_id)
REFERENCES Contact (id)
ON DELETE CASCADE
GO


INSERT INTO City (name) VALUES ('Москва')
GO

INSERT INTO City (name) VALUES ('Санкт-Петербург')
GO

INSERT INTO City (name) VALUES ('Мурманск')
GO

INSERT INTO City (name) VALUES ('Владивосток')
GO

INSERT INTO Agent (client, city_id) VALUES ('Москва Sales', 1)
GO

INSERT INTO Agent (client, city_id) VALUES ('Столичный магазин', 1)
GO

INSERT INTO Agent (client, city_id) VALUES ('Нева', 2)
GO

INSERT INTO Agent (client, city_id) VALUES ('Питер', 2)
GO

INSERT INTO Agent (client, city_id) VALUES ('Мурман Рыба', 3)
GO

INSERT INTO Agent (client, city_id) VALUES ('Владивосток 2000', 4)
GO

INSERT INTO Contact (client, sales_man) VALUES ('Продавцы онлайн','Петя')
GO

INSERT INTO Contact (client, sales_man) VALUES ('Компания продаж','Ваня')
GO

INSERT INTO Contact (client, sales_man) VALUES ('The Sellers','Даша')
GO

INSERT INTO Sale (name, agent_id, contact_id) VALUES ('Сковородка', 1, 1)
GO

INSERT INTO Sale (name, agent_id, contact_id) VALUES ('Куча гвоздей', 2, 2)
GO

INSERT INTO Sale (name, agent_id, contact_id) VALUES ('Красная рыба', 3, 3)
GO

INSERT INTO Sale (name, agent_id, contact_id) VALUES ('Мешок пуха', 4, 1)
GO

INSERT INTO Sale (name) VALUES ('Пустая закупка')
GO

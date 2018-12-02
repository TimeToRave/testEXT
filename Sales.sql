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


INSERT INTO City (name) VALUES ('������')
GO

INSERT INTO City (name) VALUES ('�����-���������')
GO

INSERT INTO City (name) VALUES ('��������')
GO

INSERT INTO City (name) VALUES ('�����������')
GO

INSERT INTO Agent (client, city_id) VALUES ('������ Sales', 1)
GO

INSERT INTO Agent (client, city_id) VALUES ('��������� �������', 1)
GO

INSERT INTO Agent (client, city_id) VALUES ('����', 2)
GO

INSERT INTO Agent (client, city_id) VALUES ('�����', 2)
GO

INSERT INTO Agent (client, city_id) VALUES ('������ ����', 3)
GO

INSERT INTO Agent (client, city_id) VALUES ('����������� 2000', 4)
GO

INSERT INTO Contact (client, sales_man) VALUES ('�������� ������','����')
GO

INSERT INTO Contact (client, sales_man) VALUES ('�������� ������','����')
GO

INSERT INTO Contact (client, sales_man) VALUES ('The Sellers','����')
GO

INSERT INTO Sale (name, agent_id, contact_id) VALUES ('����������', 1, 1)
GO

INSERT INTO Sale (name, agent_id, contact_id) VALUES ('���� �������', 2, 2)
GO

INSERT INTO Sale (name, agent_id, contact_id) VALUES ('������� ����', 3, 3)
GO

INSERT INTO Sale (name, agent_id, contact_id) VALUES ('����� ����', 4, 1)
GO

INSERT INTO Sale (name) VALUES ('������ �������')
GO

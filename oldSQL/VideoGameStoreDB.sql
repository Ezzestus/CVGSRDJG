/*
	Filename: VideoGameStoreDB.sql
	Description: Contains the MySQL DDL for creating the Video Game Store database. 
    
	Revision History: 
		Ryan Pease, 2016-10-17: Created
		Ryan Pease, 2016-10-18: Updated
		Ryan Pease, 2016-10-20: Updated
		Ryan Pease, 2016-10-21: Updated
        Ryan Pease, 2016-11-08: Updated
*/

-- ********************
-- Change all of the DATE fields to DATETIME, unless you figure out how to insert DATE objects properly - was getting exceptions when passing strings - need to convert somehow
-- ********************

DROP DATABASE IF EXISTS VideoGameStoreDB;
CREATE DATABASE VideoGameStoreDB;
USE VideoGameStoreDB;

CREATE TABLE Customer (														-- had to rename to customer table (user was a keyword) - customer is more consistent with diagrams/designs
	customer_id			INT				PRIMARY KEY		AUTO_INCREMENT,
    username			VARCHAR(15)		UNIQUE			NOT NULL,
    email				VARCHAR(25) 	UNIQUE			NOT NULL,
	customer_password	VARCHAR(25)		NOT NULL,
    login_failures		INT(1)			NOT NULL		DEFAULT 0,
    first_name			VARCHAR(15) 	NOT NULL,
    last_name			VARCHAR(15)		NOT NULL,
    phone				VARCHAR(10) 	NOT NULL,
    gender				CHAR(1)			NOT NULL,
	birthdate			DATE			NOT NULL,
	date_joined			DATE			NOT NULL,
    is_member			BIT				NOT NULL		DEFAULT 0,
    is_inactive			BIT				NOT NULL		DEFAULT 0,	
    is_locked_out		BIT				NOT NULL		DEFAULT 0,
    is_on_email_list	BIT				NOT NULL		DEFAULT 0,
    favorite_platform	VARCHAR(25),										
    favorite_category	VARCHAR(25),
    notes				VARCHAR(255)
);

CREATE TABLE Employee (
	employee_id			INT				PRIMARY KEY		AUTO_INCREMENT,
	username			VARCHAR(15)		UNIQUE			NOT NULL,
	employee_password	VARCHAR(25)		NOT NULL,
    login_failures		INT(1)			NOT NULL		DEFAULT 0,
    first_name			VARCHAR(15) 	NOT NULL,
    last_name			VARCHAR(15)		NOT NULL,
    phone				VARCHAR(10) 	NOT NULL,
    email				VARCHAR(25) 	UNIQUE			NOT NULL,
    gender				CHAR(1)			NOT NULL,
	birthdate			DATE			NOT NULL,
    date_hired			DATE			NOT NULL,
    is_admin			BIT				NOT NULL		DEFAULT 0,							
    is_inactive			BIT				NOT NULL		DEFAULT 0,
    is_locked_out		BIT				NOT NULL		DEFAULT 0,
    notes				VARCHAR(255)
);

CREATE TABLE Credit_Card (
    credit_card_id		INT				PRIMARY KEY		AUTO_INCREMENT,
    customer_id			INT				NOT NULL,
    card_number			BIGINT(16)		UNIQUE			NOT NULL,
    expiry_date			DATE			NOT NULL,
    is_expired			BIT				NOT NULL		DEFAULT 0,
    is_flagged			BIT				NOT NULL		DEFAULT 0,
    
	CONSTRAINT credit_card_customer_fk FOREIGN KEY (customer_id)
		REFERENCES Customer(customer_id));

CREATE TABLE Friend_List (
    customer_id			INT,				
	friend_id			INT,				
    is_family			BIT		 		NOT NULL		DEFAULT 0,									-- sticking with BIT - 0 for friend, 1 for family
    date_added			DATE			NOT NULL,

	CONSTRAINT friend_pk PRIMARY KEY (friend_id, customer_id),
	CONSTRAINT friend_customer_friend_fk FOREIGN KEY (friend_id)					
		REFERENCES Customer(customer_id),
	CONSTRAINT friend_customer_customer_fk FOREIGN KEY (customer_id)
		REFERENCES Customer(customer_id)
);

CREATE TABLE Developer (
	developer_id		INT				PRIMARY KEY		AUTO_INCREMENT,
    developer_name		VARCHAR(25)		UNIQUE			NOT NULL,
    contact_name		VARCHAR(25),
    contact_phone		VARCHAR(10),
    contact_email		VARCHAR(25)	
);

CREATE TABLE Publisher (
	publisher_id		INT				PRIMARY KEY		AUTO_INCREMENT,
    publisher_name		VARCHAR(25)		UNIQUE			NOT NULL,
    contact_name		VARCHAR(25),
    contact_phone		VARCHAR(10),
    contact_email		VARCHAR(25)	
);

CREATE TABLE Genre (
	genre_id			INT				PRIMARY KEY		AUTO_INCREMENT,
    genre_name			VARCHAR(20)		UNIQUE			NOT NULL,
    description			VARCHAR(255)	
);

CREATE TABLE Game (
	game_id				INT				PRIMARY KEY		AUTO_INCREMENT,
    game_name			VARCHAR(20)		UNIQUE			NOT NULL,
    description			VARCHAR(255)	NOT NULL,
    cost				DECIMAL(6,2)	NOT NULL,
    list_price			DECIMAL(6,2)	NOT NULL,
    on_hand				INT				NOT NULL,
    developer_id		INT				NOT NULL,
    publisher_id		INT				NOT NULL,
    genre_id			INT				NOT NULL,
    release_date		DATE			NOT NULL,    
    is_on_sale			BIT 			NOT NULL		DEFAULT 0,
    is_discontinued		BIT				NOT NULL		DEFAULT 0,
    is_downloadable		BIT				NOT NULL,								-- should this default to something?
    is_physical_copy	BIT				NOT NULL,								-- should this default to true?
    image_location		VARCHAR(30),

	CONSTRAINT game_developer_fk FOREIGN KEY (developer_id)
		REFERENCES Developer(developer_id),
	CONSTRAINT game_publisher_fk FOREIGN KEY (publisher_id)
		REFERENCES Publisher(publisher_id),
	CONSTRAINT game_genre_fk FOREIGN KEY (genre_id)
		REFERENCES Genre(genre_id)
);

CREATE TABLE Wish_List (
	wish_list_id		INT				PRIMARY KEY		AUTO_INCREMENT,
    customer_id			INT				NOT NULL,
    game_id				INT				NOT NULL,
    date_added			DATE			NOT NULL,

	CONSTRAINT wish_list_customer_fk FOREIGN KEY (customer_id)
		REFERENCES Customer(customer_id),
	CONSTRAINT wish_list_game_fk FOREIGN KEY (game_id)
		REFERENCES Game(game_id)
);

CREATE TABLE Customer_Game (
	customer_game_id	INT				PRIMARY KEY		AUTO_INCREMENT,
    customer_id			INT				NOT NULL,
    game_id				INT				NOT NULL,
    date_purchased		DATE			NOT NULL,								
    rating				INT(1),

	CONSTRAINT customer_game_customer_fk FOREIGN KEY (customer_id)
		REFERENCES Customer(customer_id),
	CONSTRAINT customer_game_game_fk FOREIGN KEY (game_id)
		REFERENCES Game(game_id)
);

CREATE TABLE Review (
	review_id			INT				PRIMARY KEY		AUTO_INCREMENT,
    customer_id			INT				NOT NULL,
    game_id				INT				NOT NULL,
    review_date			DATE			NOT NULL,
    is_approved			BIT				NOT NULL		DEFAULT 0,
    is_deleted			BIT				NOT NULL		DEFAULT 0,

	CONSTRAINT review_customer_fk FOREIGN KEY (customer_id)
		REFERENCES Customer(customer_id),
	CONSTRAINT review_game_fk FOREIGN KEY (game_id)
		REFERENCES Game(game_id)
);

CREATE TABLE Province (
	province_id			INT				PRIMARY KEY		AUTO_INCREMENT,
    province_code		CHAR(2)			UNIQUE			NOT NULL,
    province_name		VARCHAR(30)		UNIQUE			NOT NULL					-- necessary? i'm thinking for drop boxes / UI
);

CREATE TABLE Address (
	address_id			INT				PRIMARY KEY 	AUTO_INCREMENT,    
	street_address		VARCHAR(20)		NOT NULL,
    city				VARCHAR(20)		NOT NULL,
    province_id			INT				NOT NULL,
	postal_code			VARCHAR(6)		NOT NULL,

	CONSTRAINT address_province_fk FOREIGN KEY (province_id)
		REFERENCES Province(province_id)
);

CREATE TABLE Customer_Address (
	customer_id			INT,
    address_id			INT,
    address_name		VARCHAR(20),
    
    CONSTRAINT customer_address_pk PRIMARY KEY (customer_id, address_id),
    CONSTRAINT customer_address_address_fk FOREIGN KEY (address_id)
		REFERENCES Address(address_id),
    CONSTRAINT customer_address_customer_fk FOREIGN KEY (customer_id)
		REFERENCES Customer(customer_id)
);

CREATE TABLE Employee_Address (
	employee_id			INT,
    address_id			INT,
    address_name		VARCHAR(20),
    
    CONSTRAINT employee_address_pk PRIMARY KEY (employee_id, address_id),
    CONSTRAINT employee_address_address_fk FOREIGN KEY (address_id)
		REFERENCES Address(address_id),
    CONSTRAINT employee_address_customer_fk FOREIGN KEY (employee_id)
		REFERENCES Employee(employee_id)
);

CREATE TABLE Invoice (																-- had to rename to invoice table (order was a keyword)
	invoice_id			INT				PRIMARY KEY		AUTO_INCREMENT,				
	customer_id			INT				NOT NULL,
    credit_card_id		INT				NOT NULL,
    invoice_date		DATE			NOT NULL,
    ship_date			DATE,
    is_invoice_closed	BIT				NOT NULL		DEFAULT 0,

	CONSTRAINT invoice_credit_card_fk FOREIGN KEY (credit_card_id)
		REFERENCES Credit_Card(credit_card_id),
	CONSTRAINT invoice_customer_fk FOREIGN KEY (customer_id)
		REFERENCES Customer(customer_id)
);

CREATE TABLE Line_Item (
	line_item_id		INT				PRIMARY KEY		AUTO_INCREMENT,
    invoice_id			INT				NOT NULL,
    game_id				INT				NOT NULL,
    quantity			INT				NOT NULL,
    price				DECIMAL(6,2) 	NOT NULL,

	CONSTRAINT line_item_invoice_fk FOREIGN KEY (invoice_id)
		REFERENCES Invoice(invoice_id),
	CONSTRAINT line_item_game_fk FOREIGN KEY (game_id)
		REFERENCES Game(game_id)
);

CREATE TABLE Invoice_Address (
	invoice_address_id	INT				PRIMARY KEY		AUTO_INCREMENT,
    invoice_id			INT				NOT NULL,
    address_id			INT				NOT NULL,
    is_billing_address	BIT				NOT NULL,									-- default to true?

	CONSTRAINT invoice_address_invoice_fk FOREIGN KEY (invoice_id)
		REFERENCES Invoice(invoice_id),
    CONSTRAINT invoice_address_address_fk FOREIGN KEY (address_id)
		REFERENCES Address(address_id)
);

CREATE TABLE Store_Event (																-- had to rename from 'event' since it's an SQL keyword
	store_event_id		INT				PRIMARY KEY		AUTO_INCREMENT,
    store_event_name	VARCHAR(50)		UNIQUE			NOT NULL,
    description			VARCHAR(255)	NOT NULL,
    address_id			INT				NOT NULL,
    start_date			DATE			NOT NULL,
    end_date			DATE			NOT NULL,
    max_registrants		INT				NOT NULL,
    is_full				BIT				NOT NULL		DEFAULT 0,
    is_members_only		BIT				NOT NULL		DEFAULT 0,
    is_cancelled		BIT				NOT NULL		DEFAULT 0,

	CONSTRAINT store_event_address_fk FOREIGN KEY (address_id)
		REFERENCES Address(address_id)
);

CREATE TABLE Store_Event_Customer (
	store_event_customer_id	INT				PRIMARY KEY		AUTO_INCREMENT,
    store_event_id			INT				NOT NULL,
    customer_id				INT				NOT NULL,

	CONSTRAINT store_event_customer_store_event_fk FOREIGN KEY (store_event_id)
		REFERENCES Store_Event(store_event_id),
	CONSTRAINT store_event_customer_customer_fk FOREIGN KEY (customer_id)
		REFERENCES Customer(customer_id)
);

CREATE TABLE Store_Event_Employee (
	store_event_employee_id		INT			PRIMARY KEY		AUTO_INCREMENT,
    store_event_id				INT			NOT NULL,
    employee_id					INT			NOT NULL,

	CONSTRAINT store_event_employee_store_event_fk FOREIGN KEY (store_event_id)
		REFERENCES Store_Event(store_event_id),
    CONSTRAINT store_event_employee_fk FOREIGN KEY (employee_id)
		REFERENCES Employee(employee_id)
);
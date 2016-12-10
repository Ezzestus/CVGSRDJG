/*
	Filename: VideoGameStore - Insert Data.sql
	Description: Contains the MySQL DML code to insert data into the database.
    
	Revision History: 		
		Ryan Pease, 2016-10-20: Created
        Ryan Pease, 2016-10-21: Updated
        Ryan Pease, 2016-11-08: Updated
        Ryan Pease, 2016-11-19: Updated

*/
-- ADDED CREDIT_CARD_ID to Invoice table - should be able to do a drop down based on query of all Creditcards where user_id = user_id
-- Change all of the DATE data types to DATETIME, then use STR_TO_DATE() method like in the GAME Insert code below

USE VideoGameStoreDB;

-- User
INSERT INTO User 
	(username, email, user_password, first_name, last_name, phone, gender, birthdate, date_joined, is_employee, is_admin, is_member)
VALUES
	('ryan', 'ryan@ryan.com', 'ANagF5pACw8bWXD3JRuCtA8SegZ8nsMBHrXDO2ft2O+pBFoS00eAioot+4kkYTZxFg==', 'Ryan', 'Pease', '0000000000', 'M', '1900-01-01', STR_TO_DATE('2010-01-01', '%Y-%m-%d'), 1, 1, 0),
    ('greg', 'greg@greg.com', 'ACjM6xRoDtVixePBySFp844cN8GN7TgDGPw2ghFmkwcj+0cXj8J9XHtdYl7ICO4P5w==', 'Greg', 'Shalay', '1111111111', 'M', '1900-02-02', STR_TO_DATE('2010-02-02', '%Y-%m-%d'), 1, 1, 0),
    ('john', 'john@john.com', 'AC9w3EG4H92LQdYvuvLfSi2QOzz5WCFEHRNlOnA4hE9W7GfFMc0EKyCpnqnmS/EAJw==', 'John', 'Lambert', '2222222222', 'M', '1900-03-03', STR_TO_DATE('2010-03-03', '%Y-%m-%d'), 1, 1, 0),
    ('david', 'dave@dave.com', 'ANAHXTULQR22pvARxPERchZ7mL/AdmHRbaAzD25Iup7NT9aE/aE84/YjXH2dYKPS3g==', 'David', 'Klumpenhower', '3333333333', 'M', '1900-04-04', STR_TO_DATE('2010-04-04', '%Y-%m-%d'), 1, 1, 0),
	('random', 'guy@guy.com', 'AHDDN6k6I51+SJxkpeTxRbeG3yXM4eBBOCRNBXp+kF2yiy0FycZtPUt78klPQNYWOQ==', 'That', 'Guy', '4444444444', 'M', '1900-05-05', STR_TO_DATE('2015-02-22', '%Y-%m-%d'), 1, 0, 0),
    ('roger1', 'roger@gmail.com', 'ALycndFcL1u8itCwRZUr9MTaf2xe93+GLaxonMfepgGqdDPOVF7rrTMMdpBD8AuTRQ==', 'Roger', 'Wilco', '0000000000', 'M', '1999-09-09', STR_TO_DATE('2015-01-01', '%Y-%m-%d'), 0, 0, 1),
    ('superstar', 'star@super.com', 'AJwYg5lVHP43UTIP+0CTnFbnPhXxuwExFH86HyiQFllVmEVKTPVrJEdQIP4iIZgSEg==', 'Mister', 'Mister', '1234567890', 'M', '1985-11-22', STR_TO_DATE('2015-04-04', '%Y-%m-%d'), 0, 0, 0),
    ('mstaken', 'notfake@hotmail.com', 'AEagFJfUwU0fDJUmVUaE6OkrvinCwcy/yvL9/3MBPzdQn3L5VC7iQXNttw6Y9ilPUw==', 'Barbara', 'Gordon', '9999999999', 'F', '1988-02-18', STR_TO_DATE('2016-06-06', '%Y-%m-%d'), 0, 0, 1);
    
    
-- FRIEND_LIST
INSERT INTO Friend_List
	(user_id, friend_id, date_added)
VALUES
	(1, 2, STR_TO_DATE('2015-05-05', '%Y-%m-%d')),
    (2, 3, STR_TO_DATE('2016-08-08', '%Y-%m-%d'));
    
    
-- CREDIT_CARD
INSERT INTO Credit_Card
	(user_id, card_number, expiry_date)
VALUES
	(1, 1234123412341234, STR_TO_DATE('2020-01-01', '%Y-%m-%d'));


-- DEVELOPER
INSERT INTO Developer 
    (developer_name)
VALUES
	('Bethesda'),
    ('Bioware'),
	('Firaxis'),
    ('Id'),
    ('Nintendo'),
    ('Square Enix'),
    ('Valve');  	


-- PUBLISHER
INSERT INTO Publisher
	(publisher_name)
VALUES
	('Nintendo'),
    ('Ubisoft'),
    ('Electronic Arts'),
    ('Sony'),
    ('Square Enix'),
    ('Microsoft'),
    ('Activision Blizzard'),
    ('2K Games');
	
    
-- GENRE
INSERT INTO Genre
	(genre_name)			-- add description data?
VALUES
	('RPG'),
    ('Shooter'),
    ('Sports'),
    ('Strategy'),
    ('Platform'),
    ('Simulation'),
    ('Puzzle');


-- GAME
INSERT INTO Game 
	(game_name, description, cost, list_price, on_hand, developer_id, publisher_id, genre_id, release_date, is_downloadable, is_physical_copy, image_location)
VALUES
	('Mass Effect', 'Mass Effect is a science fiction action role-playing third-person shooter video game series developed by the Canadian company BioWare and released for the Xbox 360, PlayStation 3, and Microsoft Windows.', 20.00, 29.99, 2, 4, 6, 1, STR_TO_DATE('2007-11-20', '%Y-%m-%d'), 0, 1, 'mass_effect.jpg'),
    ('Final Fantasy VII', 'Final Fantasy VII is a role-playing video game developed and published by Square for the PlayStation platform.', 5.00, 9.99, 1, 5, 5, 1, STR_TO_DATE('1997-01-31', '%Y-%m-%d'), 0, 1, 'final_fantasy_vii.jpg'),
    ('Civilization 4', 'Sid Meier\'s Civilization IV is a turn-based strategy computer game and the fourth installment of the Civilization series.', 10, 14.99, 3, 7, 8, 4, STR_TO_DATE('2005-10-25', '%Y-%m-%d'), 0, 1, 'civilization_4.jpg'),
    ('Super Mario World', 'Super Mario World, subtitled Super Mario Bros. 4 for its original Japanese release, is a 1990 platform video game developed and published by Nintendo as a pack-in launch title for the Super Nintendo Entertainment System.', 3, 4.99, 1, 6, 1, 5, STR_TO_DATE('1990-11-21', '%Y-%m-%d'), 0, 1, 'super_mario_world.jpg');


-- WISH_LIST
INSERT INTO Wish_List
	(user_id, game_id, date_added)
VALUES	
	(3, 2, STR_TO_DATE('2016-09-09', '%Y-%m-%d'));


-- USER_GAME
INSERT INTO User_Game
	(user_id, game_id, date_purchased, rating)
VALUES
	(1, 1, STR_TO_DATE('2016-10-01', '%Y-%m-%d'), 5),
    (2, 2, STR_TO_DATE('2016-10-04', '%Y-%m-%d'), NULL);


-- REVIEW
INSERT INTO Review
	(user_id, game_id, review_date, is_approved)
VALUES
	(1, 1, STR_TO_DATE('2016-10-12', '%Y-%m-%d'), 1),
    (2, 1, STR_TO_DATE('2016-10-31', '%Y-%m-%d'), 0);


-- PROVINCE
INSERT INTO Province
	(province_code, province_name)
VALUES
	('AB', 'Alberta'),
    ('BC', 'British Columbia'),
    ('MB', 'Manitoba'),
    ('NB', 'New Brunswick'),
    ('NL', 'Newfoundland'),
    ('NS', 'Nova Scotia'),
    ('NT', 'Northwest Territories'),
    ('NU', 'Nunavut'),
    ('ON', 'Ontario'),
    ('PE', 'Prince Edward Island'),
    ('QC', 'Quebec'),
    ('SK', 'Saskatchewan'),
    ('YT', 'Yukon');
    
    
-- ADDRESS
INSERT INTO Address
	(street_address, city, province_id, postal_code)
VALUES
	('41 Avenue Rd.', 'Toronto', 9, 'M4M4M4'),
    ('22 Yonge St.', 'Toronto', 9, 'M3M3M3'),
    ('99 Mt. Pleasant Ave.', 'Toronto', 9, 'M4M3M3'),
    ('123 King St.', 'Toronto', 9, 'M4M2N2');			-- the store address


-- USER_ADDRESS
INSERT INTO User_Address
	(user_id, address_id)
VALUES 
	(1, 1);
    

-- ****** how to add credit card? could lookup if user has any, but what if not?  --> Add a link in view
-- INVOICE
INSERT INTO Invoice									
	(user_id, credit_card_id, invoice_date)
VALUES
	(1, 1, STR_TO_DATE('2016-10-01', '%Y-%m-%d'));


-- INVOICE_ADDRESS
INSERT INTO Invoice_Address
	(invoice_id, address_id, is_billing_address)
VALUES
	(1, 3, 1);
    

-- *** how to ensure correct price/total is retained - don't want it to change with the changes in price in the future (want a snapshot of that time - not to fluctuate based on when a subquery is executed)
-- LINE_ITEM
INSERT INTO Line_Item							
	(invoice_id, game_id, quantity, price)
VALUES
	(1, 1, 2, 29.99);


-- STORE_EVENT
INSERT INTO Store_Event
	(store_event_name, description, address_id, start_date, end_date, max_registrants)
VALUES ('Customer Appreciation Sale', 'The biggest sale of the year for our best customers!', 4, STR_TO_DATE('2017-01-01', '%Y-%m-%d'),  STR_TO_DATE('2017-01-07', '%Y-%m-%d'), 100);

    
-- STORE_EVENT_USER
INSERT INTO Store_Event_User
	(store_event_id, user_id)
VALUES
	(1, 1),
	(1, 2),
    (1, 3), 
    (1, 4),
    (1, 6),
    (1, 7);
    

CREATE database dengue;
USE dengue;

CREATE TABLE cases (
	id INT AUTO_INCREMENT PRIMARY KEY,
    birthdate DATE NOT NULL,
    case_date_in DATE NOT NULL,
    case_date_out DATE NOT NULL,
    subdistrict VARCHAR(30)
);

LOAD DATA LOCAL INFILE 'C:\\Users\\yemis\\Documents\\databasedengue.txt' INTO TABLE cases LINES terminated by'\r\n' (birthdate, case_date_in,case_date_out,subdistrict);
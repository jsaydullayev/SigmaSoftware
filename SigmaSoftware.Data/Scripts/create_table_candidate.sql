Create Table my.candidate
(
	id uuid NOT NULL PRIMARY KEY,
	first_name varchar(50) NOT NULL,
	last_name varchar(50) NOT NULL,
	phone_number varchar(20) NOT NULL,
	email varchar(100) NOT NULL,
	call_start_time TIME NOT NULL,
    call_end_time TIME NOT NULL,
	linkedin_profile varchar(100) NOT NULL,
	git_hub_profile varchar(100) NOT NULL,
	description varchar(500)
);
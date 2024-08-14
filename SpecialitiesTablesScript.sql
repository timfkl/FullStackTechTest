CREATE TABLE PeopleSpecialities(
	Id INT PRIMARY KEY auto_increment,
    PersonId INT NOT NULL,
    SpecialityId INT NOT NULL
);

CREATE TABLE Specialities(
	Id INT PRIMARY KEY auto_increment,
    SpecialityName VARCHAR(32)
);

INSERT INTO Specialities (SpecialityName) VALUES ('Anaesthetics'), ('Cardiology'), ('Dermatology'),
('Emergency Medicine'), ('General Practice (GP)'), ('Neurology'), ('Obstetrics and Gynaecology'),
('Ophthalmology'), ('Orthopaedic Surgery'), ('Psychiatry');
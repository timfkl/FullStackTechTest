CREATE TABLE PersonSpecialities(
	Id INT PRIMARY KEY auto_increment,
    PersonId INT NOT NULL,
    SpecialityId INT NOT NULL
);

CREATE TABLE Speciality(
	Id INT PRIMARY KEY auto_increment,
    SpecialityName VARCHAR(32)
);

INSERT INTO Speciality (SpecialityName) VALUES ('Anaesthetics'), ('Cardiology'), ('Dermatology'),
('Emergency Medicine'), ('General Practice (GP)'), ('Neurology'), ('Obstetrics and Gynaecology'),
('Ophthalmology'), ('Orthopaedic Surgery'), ('Psychiatry');
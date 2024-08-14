CREATE TABLE DoctorSpecialities(
	Id INT PRIMARY KEY auto_increment,
    GMC INT,
    SpecialityId INT
);

CREATE TABLE Specialities(
	Id INT PRIMARY KEY auto_increment,
    SpecialityName VARCHAR(32)
);

INSERT INTO Specialities (SpecialityName) VALUES ('Anaesthetics'), ('Cardiology'), ('Dermatology'),
('Emergency Medicine'), ('General Practice (GP)'), ('Neurology'), ('Obstetrics and Gynaecology'),
('Ophthalmology'), ('Orthopaedic Surgery'), ('Psychiatry');
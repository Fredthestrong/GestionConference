# GestionConference
--------Concevoir un système  d’information (SI) capable de gérer l’organisation et la gestion de conférences  scientifiques ---

Entités principales
Administrateur
Conférence
Article
Auteur
Université
Entreprise
Relecteur
Participant
Evaluation
Data Transfer Objects (DTOs)
ConférenceDto
ArticleDto
AuteurDto
UniversitéDto
EntrepriseDto
RelecteurDto
ParticipantDto
EvaluationDto

Les classes dans le dossier Models représentent les entités du domaine, souvent directement mappées aux tables de la base de données, et sont utilisées pour les opérations CRUD (Create, Read, Update, Delete). Les classes dans le dossier ModelsDto sont utilisées pour transférer des données entre les différentes couches de l'application, notamment pour les interactions API ou les réponses de services.

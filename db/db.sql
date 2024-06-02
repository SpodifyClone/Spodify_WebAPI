CREATE TABLE Users (
    id SERIAL PRIMARY KEY,
    username VARCHAR(255) NOT NULL UNIQUE,
    email VARCHAR(255) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    role VARCHAR(50) CHECK (role IN ('u', 'a', 's')) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Music (
    id SERIAL PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    artist VARCHAR(255) NOT NULL,
    release_date DATE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Playlists (
    id SERIAL PRIMARY KEY,
    user_id INT REFERENCES Users(id) ON DELETE CASCADE,
    name VARCHAR(255) NOT NULL,
    description TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Playlist_Music (
    playlist_id INT REFERENCES Playlists(id) ON DELETE CASCADE,
    music_id INT REFERENCES Music(id) ON DELETE CASCADE,
    PRIMARY KEY (playlist_id, music_id)
);

CREATE TABLE Liked_Playlists (
    user_id INT REFERENCES Users(id) ON DELETE CASCADE,
    playlist_id INT REFERENCES Playlists(id) ON DELETE CASCADE,
    liked_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (user_id, playlist_id)
);

CREATE TABLE Liked_Musics (
    user_id INT REFERENCES Users(id) ON DELETE CASCADE,
    music_id INT REFERENCES Music(id) ON DELETE CASCADE,
    liked_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (user_id, music_id)
);


CREATE TABLE Views (
    user_id INT REFERENCES Users(id) ON DELETE CASCADE,
    music_id INT REFERENCES Music(id) ON DELETE CASCADE,
    viewed_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (user_id, music_id)
);


CREATE VIEW AllUsers AS
SELECT id, username, email, role, created_at
FROM Users;

CREATE VIEW AllMusic AS
SELECT id, title, artist, release_date, created_at
FROM Music;

CREATE VIEW AllPlaylists AS
SELECT p.id, p.name, p.description, p.created_at, u.username AS created_by
FROM Playlists p
JOIN Users u ON p.user_id = u.id;

CREATE VIEW PlaylistTracks AS
SELECT p.id AS playlist_id, p.name AS playlist_name, m.id AS music_id, m.title AS music_title, m.artist AS music_artist
FROM Playlists p
JOIN Playlist_Music pm ON p.id = pm.playlist_id
JOIN Music m ON pm.music_id = m.id;

CREATE VIEW UserLikedPlaylists AS
SELECT u.id AS user_id, u.username, p.id AS playlist_id, p.name AS playlist_name, lp.liked_at
FROM Users u
JOIN Liked_Playlists lp ON u.id = lp.user_id
JOIN Playlists p ON lp.playlist_id = p.id;

CREATE VIEW UserLikedMusics AS
SELECT u.id AS user_id, u.username, m.id AS music_id, m.title AS music_title, lm.liked_at
FROM Users u
JOIN Liked_Musics lm ON u.id = lm.user_id
JOIN Music m ON lm.music_id = m.id;

CREATE VIEW UserViewedMusics AS
SELECT u.id AS user_id, u.username, m.id AS music_id, m.title AS music_title, v.viewed_at
FROM Users u
JOIN Views v ON u.id = v.user_id
JOIN Music m ON v.music_id = m.id;

CREATE VIEW MusicViewedByUsers AS
SELECT m.id AS music_id, m.title AS music_title, u.id AS user_id, u.username, v.viewed_at
FROM Music m
JOIN Views v ON m.id = v.music_id
JOIN Users u ON v.user_id = u.id;




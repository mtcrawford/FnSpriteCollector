let db = null;

export async function openDb(dbName, version) {
    return new Promise((resolve, reject) => {
        const request = indexedDB.open(dbName, version);

        request.onupgradeneeded = (event) => {
            const database = event.target.result;

            if (!database.objectStoreNames.contains("FNSprites")) {
                database.createObjectStore("FNSprites", { keyPath: "Id" });                
            }

            if (!database.objectStoreNames.contains("OwnedSprites")) {
                database.createObjectStore("OwnedSprites", { keyPath: "Id" });
            }            
        };

        request.onsuccess = (event) => {
            db = event.target.result;
            resolve(true);
        };

        request.onerror = (event) => reject(event.target.error);
    });
}

export async function getItem(storeName, key) {
    return new Promise((resolve, reject) => {
        const transaction = db.transaction(storeName, "readonly");
        const store = transaction.objectStore(storeName);
        const request = store.get(key);

        request.onsuccess = () =>
            resolve(request.result ? JSON.stringify(request.result) : null);

        request.onerror = () => reject(request.error);
    });
}

export async function setItem(storeName, key, value) {
    return new Promise((resolve, reject) => {
        const transaction = db.transaction(storeName, "readwrite");
        const store = transaction.objectStore(storeName);

        // Assumes 'value' contains the keyPath property (Id)
        const request = store.put(JSON.parse(value));

        request.onsuccess = () => resolve();

        request.onerror = () => reject(request.error);
    });
}

export async function getAll(storeName) {
    return new Promise((resolve, reject) => {
        const transaction = db.transaction(storeName, "readonly");
        const store = transaction.objectStore(storeName);
        const request = store.getAll();

        request.onsuccess = () =>
            resolve(JSON.stringify(request.result));

        request.onerror = () => reject(request.error);
    });
}

export async function deleteItem(storeName, key) {
    return new Promise((resolve, reject) => {
        const transaction = db.transaction(storeName, "readwrite");
        const store = transaction.objectStore(storeName);
        const request = store.delete(key);

        request.onsuccess = () => resolve();

        request.onerror = () => reject(request.error);
    });
}

export async function clearStore(storeName) {
    return new Promise((resolve, reject) => {
        const transaction = db.transaction(storeName, "readwrite");
        const store = transaction.objectStore(storeName);
        const request = store.clear();

        request.onsuccess = () => resolve();

        request.onerror = () => reject(request.error);
    });
}
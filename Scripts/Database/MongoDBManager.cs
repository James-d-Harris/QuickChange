using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class MongoDBManager : MonoBehaviour
{
    // MongoDB Client, Database, and Collection instances
    private MongoClient mongoClient;
    private IMongoDatabase database;
    private IMongoCollection<BsonDocument> collection;

    // MongoDB connection string
    private string connectionString = "mongodb+srv://UnityAccess:UpUuwujgAUnzUoro@cluster0.drcxz.mongodb.net/?retryWrites=true&w=majority";
    private string databaseName = "QuickChangeDB";
    private string collectionName = "general"; // Change based on the school's collection

    // Initialize MongoDB connection
    void Start()
    {
        ConnectToMongoDB();
    }

    // Method to connect to MongoDB with Server API version setting
    private void ConnectToMongoDB()
    {
        try
        {
            // Use MongoDB.ClientSettings to configure the connection
            var settings = MongoClientSettings.FromConnectionString(connectionString);

            // Set the ServerApi version to V1
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            // Create the MongoClient instance with the configured settings
            mongoClient = new MongoClient(settings);

            // Get the database and collection
            database = mongoClient.GetDatabase(databaseName);
            collection = database.GetCollection<BsonDocument>(collectionName);

            // Send a ping to confirm the connection
            var result = database.RunCommand<BsonDocument>(new BsonDocument("ping", 1));
            Debug.Log("Pinged your deployment. You successfully connected to MongoDB!");
        }
        catch (System.Exception e)
        {
            Debug.LogError("MongoDB Connection Error: " + e.Message);
        }
    }

    // Example method to insert a user document
    public async Task InsertUser(string username, string password, bool teacher)
    {
        var document = new BsonDocument
        {
            { "username", username },
            { "password", password },
            { "teacher", teacher },
            { "successfulLevels", 0 },
            { "failedLevels", 0 }
        };

        try
        {
            await collection.InsertOneAsync(document);
            Debug.Log("User inserted successfully!");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Insert User Error: " + e.Message);
        }
    }

    // Example method to validate user credentials
    public async Task<bool> ValidateUser(string username, string password)
    {
        var filter = Builders<BsonDocument>.Filter.Eq("username", username) & Builders<BsonDocument>.Filter.Eq("password", password);
        Debug.Log("Attempting validation");

        try
        {
            var result = await collection.Find(filter).FirstOrDefaultAsync();
            if (result != null)
            {
                Debug.Log("User authenticated successfully!");
                return true;
            }
            else
            {
                Debug.LogWarning("Invalid username or password.");
                return false;
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Validate User Error: " + e.Message);
            return false;
        }
    }

    // Example method to retrieve all users (for teacher dashboard)
    public async Task<List<BsonDocument>> GetAllUsers()
    {
        try
        {
            var users = await collection.Find(new BsonDocument()).ToListAsync();
            return users;
        }
        catch (System.Exception e)
        {
            Debug.LogError("Get All Users Error: " + e.Message);
            return null;
        }
    }
}

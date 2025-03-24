namespace Final_app
{
    internal interface SerializableToSave
    {
        public string Serialize();

        public SerializableToSave Deserialize(string serialized);
    }
}
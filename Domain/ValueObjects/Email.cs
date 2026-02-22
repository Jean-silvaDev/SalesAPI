namespace Domain.ValueObjects;

public class Email
{
    public string Address { get; }

    public Email(string address)
    {
        if (!address.Contains("@"))
            throw new Exception("Email inválido");

        Address = address;
    }
}

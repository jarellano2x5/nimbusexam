namespace exanim.core.Helpers;

public interface IHashHelper
{
    string Create(string pwd);
    bool Compute(string pwd, string check);
}
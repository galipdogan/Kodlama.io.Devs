namespace Core.Persistence.Paging;

public interface IPaginate<T>
{
    int From { get; } //nerden
    int Index { get; } //kacıncı 
    int Size { get; } //sayfada kac tane
    int Count { get; } //toplam sayı
    int Pages { get; } //kacıncı sayfa
    IList<T> Items { get; }
    bool HasPrevious { get; } //oncesı varmı
    bool HasNext { get; }//sonrası varmı
}
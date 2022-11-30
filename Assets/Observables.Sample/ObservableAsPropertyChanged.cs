using UnityEngine;

namespace Observables.Sample
{
    public class ObservableAsPropertyChanged : MonoBehaviour
    {
        private int _nameIndex;
        private readonly Observable<string> _name = new(string.Empty);
        private readonly CompositeDisposable _disposables = new();

        private readonly string[] _names =
        {
            "James",
            "Mary",
            "Robert",
            "Patricia",
            "John",
            "Jennifer"
        };

        private void OnEnable()
        {
            _disposables.Add(
                _name.Then((prev, curr) => { Debug.Log($"Name changed {prev} → {curr}"); })
            );

            InvokeRepeating(nameof(TraverseNames), 1f, 1f);
        }

        private void OnDisable()
        {
            _disposables.Dispose();
            CancelInvoke();
        }

        private void TraverseNames()
        {
            _nameIndex = (_nameIndex + 1) % _names.Length;
            _name.Push(_names[_nameIndex]);
        }
    }
}
using UnityEngine;

namespace Observables.Sample
{
    public class ObservableAsVoidEvent : MonoBehaviour
    {
        private readonly Observable<object> _onTick = new();
        private readonly CompositeDisposable _disposables = new();

        private void OnEnable()
        {
            _disposables.Add(_onTick.Then(() => { Debug.Log("Tick!"); }));
            InvokeRepeating(nameof(InvokeEvent), 1f, 1f);
        }

        private void OnDisable()
        {
            _disposables.Dispose();
        }

        private void InvokeEvent()
        {
            _onTick.Push(null);
        }
    }
}
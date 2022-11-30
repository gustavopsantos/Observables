using UnityEngine;

namespace Observables.Sample
{
    public class ObservableAsTypedEvent : MonoBehaviour
    {
        private int _tick;
        private readonly Observable<int> _onTick = new(0);
        private readonly CompositeDisposable _disposables = new();

        private void OnEnable()
        {
            _disposables.Add(
                _onTick.Then((tick) => { Debug.Log($"Tick: {tick}"); }));
            InvokeRepeating(nameof(InvokeEvent), 1, 1);
        }

        private void OnDisable()
        {
            _disposables.Dispose();
        }

        private void InvokeEvent()
        {
            _onTick.Push(_tick++);
        }
    }
}
using Scripts.GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.GamePlay.UI
{
    public class UIHealth : MonoBehaviour
    {
        protected Health health;

        protected virtual void Start()
        {
            health = transform.root.GetComponent<Health>();

            health.CurrentHealthValueChanged += OnCurrentHealthValueChanged;
        }

        private void OnDestroy()
        {
            health.CurrentHealthValueChanged -= OnCurrentHealthValueChanged;
        }

        protected virtual void OnCurrentHealthValueChanged() { }

    }
}
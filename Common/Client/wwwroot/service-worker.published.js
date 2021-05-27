self.addEventListener('fetch', () => { });

self.addEventListener('push', event => {
    const payload = event.data.json();
    event.waitUntil(
        self.registration.showNotification('Investment app', {
            body: payload.message,
            icon: 'images/InvestmentAppIcon.png',
            vibrate: [100, 50, 100],
            data: { url: payload.url },
            actions: [{ action: 'view', title: 'View' }]
        })
    );
});

self.addEventListener('notificationclick', function (event) {
    event.notification.close();

    if (event.action === 'view') {
        clients.openWindow(event.notification.data.url);
    }
}, false);
import numpy as np
import matplotlib.pyplot as plt
from numpy.linalg import norm

cluster_1 = np.random.randn(100, 2) + [2, 2]  
cluster_2 = np.random.randn(100, 2) + [-2, -2]  
cluster_3 = np.random.randn(100, 2) + [5, -3]  

X = np.concatenate([cluster_1, cluster_2, cluster_3])

class KMeans:
    def _init_(self, k=3, tolerance=0.0001, max_iters=100):
        self.k = k
        self.tolerance = tolerance
        self.max_iters = max_iters
        self.centroids = []
        self.inertia = 0.0

    def init_centroids(self, X):
        indices = np.random.choice(len(X), self.k, replace=False)
        return X[indices]

    def assign_clusters(self, X):
        labels = []
        for point in X:
            dists = [norm(point - c) for c in self.centroids]
            labels.append(np.argmin(dists))
        return np.array(labels)

    def update_centroids(self, X, labels):
        new_centroids = []
        for i in range(self.k):
            cluster = X[labels == i]
            if len(cluster) > 0:
                new_centroids.append(np.mean(cluster, axis=0))
            else:
                new_centroids.append(X[np.random.randint(len(X))])
        return np.array(new_centroids)

    def compute_inertia(self, X, labels):
        self.inertia = 0.0
        for i in range(self.k):
            cluster = X[labels == i]
            self.inertia += np.sum(norm(cluster - self.centroids[i], axis=1) ** 2)
        return self.inertia

    def fit(self, X):
        self.centroids = self.init_centroids(X)

        for i in range(self.max_iters):
            labels = self.assign_clusters(X)
            old_centroids = self.centroids.copy()
            self.centroids = self.update_centroids(X, labels)

            total_movement = 0.0
            for j in range(self.k):
                move = norm(old_centroids[j] - self.centroids[j])
                total_movement += move
            if total_movement < self.tolerance:
                print("Stopped after", i + 1, "iterations (converged).")
                break

        self.compute_inertia(X, labels)
        return self.centroids, labels, self.inertia

model = KMeans(k=3)
centroids, labels, inertia = model.fit(X)

print("Centroids:")
print(centroids)
print("Inertia:", inertia)

plt.figure(figsize=(8, 5))
plt.scatter(X[:, 0], X[:, 1], c=labels, cmap='viridis', s=30)
plt.scatter(centroids[:, 0], centroids[:, 1], c='red', marker='X', s=200, label='Centroids')
plt.title("K-Means  ")
plt.legend()
plt.grid(True)
plt.show()
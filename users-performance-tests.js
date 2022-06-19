import http from "k6/http";
import { check } from "k6";

export default function () {
  const allUsers = http.get(
    "https://c5a64610f3e4b4242355416d12d290df.gr7.eu-central-1.eks.amazonaws.com/api/v1/users"
  );
  check(allUsers, {
    "is status 200": (r) => r.status === 200,
  });
  const userbyId = http.get(
    "https://c5a64610f3e4b4242355416d12d290df.gr7.eu-central-1.eks.amazonaws.com/api/v1/users/1"
  );
  check(userbyId, {
    "is status 200": (r) => r.status === 200,
  });
  const createUser = http.post(
    "https://c5a64610f3e4b4242355416d12d290df.gr7.eu-central-1.eks.amazonaws.com/api/v1/users",
    {
      "Content-Type": "application/json",
      "X-Requested-With": "XMLHttpRequest",
      "X-CSRF-Token": "1",
      body: JSON.stringify({
        user: {
          email: "test@email.com",
          password: "testpassword",
          password_confirmation: "testpassword",
          first_name: "Test",
          last_name: "User",
          created_at: "2020-04-01T00:00:00.000Z",
          updated_at: "2020-04-01T00:00:00.000Z",
        },
      }),
    }
  );
  check(createUser, {
    "is status 200": (r) => r.status === 200,
  });
  const deleteUser = http.delete(
    "https://c5a64610f3e4b4242355416d12d290df.gr7.eu-central-1.eks.amazonaws.com/api/v1/users/1"
  );
  check(deleteUser, {
    "is status 200": (r) => r.status === 200,
  });
}

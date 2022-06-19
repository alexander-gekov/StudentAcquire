import http from "k6/http";
import { check } from "k6";

export default function () {
  const allListings = http.get(
    "https://c5a64610f3e4b4242355416d12d290df.gr7.eu-central-1.eks.amazonaws.com/api/v1/listings"
  );
  check(allListings, {
    "is status 200": (r) => r.status === 200,
  });
  const listingById = http.get(
    "https://c5a64610f3e4b4242355416d12d290df.gr7.eu-central-1.eks.amazonaws.com/api/v1/listings/1"
  );
  check(listingById, {
    "is status 200": (r) => r.status === 200,
  });
  const createLisitng = http.post(
    "https://c5a64610f3e4b4242355416d12d290df.gr7.eu-central-1.eks.amazonaws.com/api/v1/listings",
    {
      "Content-Type": "application/json",
      "X-Requested-With": "XMLHttpRequest",
      "X-CSRF-Token": "1",
      body: JSON.stringify({
        listing: {
          title: "Test Listing",
          description: "Test Description",
          price: "100",
          category: "Test Category",
          image:
            "https://www.google.com/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png",
          user_id: 1,
          status: "active",
          created_at: "2020-04-01T00:00:00.000Z",
          updated_at: "2020-04-01T00:00:00.000Z",
        },
      }),
    }
  );
  check(createLisitng, {
    "is status 200": (r) => r.status === 200,
  });
  const deleteListing = http.delete(
    "https://c5a64610f3e4b4242355416d12d290df.gr7.eu-central-1.eks.amazonaws.com/api/v1/listings/1"
  );
  check(deleteListing, {
    "is status 200": (r) => r.status === 200,
  });
}
